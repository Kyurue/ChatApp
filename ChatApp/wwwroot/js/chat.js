"use strict";
import { template } from "/js/modules/template.js";
import { Message } from "/js/components/message.js";
import { SenderMessage } from "/js/components/senderMessage.js";


//attach templates
template.attachTemplates();
const chat = document.getElementById("chat");

const url = window.location.href.replace(/\/$/, '');
const lastSeg = url.substring(url.lastIndexOf('/') + 1);
const groupId = lastSeg.substring(0, 10);

//build connection 
const connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//disable button temporarily
document.getElementById("sendButton").disabled = true;

//receive message
connection.on("ReceiveMessage", function (message, time, user = null) {
    if (user) {
        chat.appendChild(new Message(message, (time.split('T')[1]).slice(0, 8), user));
    } else {
        chat.appendChild(new SenderMessage(message, (time.split('T')[1]).slice(0, 8)));
    }
});

//if connection is ready
connection.start().then(async () => {
    //enable send button
    document.getElementById("sendButton").disabled = false;

    const response = await fetch(`/api/messages/${groupId}`);
    const data = await response.json();

    data.forEach((element) => {
        if (element["username"]) {
            chat.appendChild(new Message(element["message"], (element["createdAt"].split('T')[1]).slice(0, 8), element["username"]));
        } else {
            chat.appendChild(new SenderMessage(element["message"], (element["createdAt"].split('T')[1]).slice(0, 8)));
        }
    });

    connection.invoke("Join", groupId).catch(function (err) {
        return console.error(err.toString());
    });

//catch if fails
}).catch(function (err) {
    return console.error(err.toString());
});

//Send message
document.getElementById("sendButton").addEventListener("click", function (event) {
    //Get message
    const message = document.getElementById("messageInput").value;

    connection.invoke("SendMessage", message, groupId).catch(function (err) {
        return console.error(err.toString());
    });

    event.preventDefault();
});
