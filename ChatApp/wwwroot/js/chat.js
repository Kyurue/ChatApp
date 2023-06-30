"use strict";
import { template } from "/js/modules/template.js";
import { Message } from "/js/components/message.js";
import { SenderMessage } from "/js/components/senderMessage.js";

//attach templates
template.attachTemplates();
const chat = document.getElementById("chat");

//get groupId
const url = window.location.href.replace(/\/$/, '');
const lastSeg = url.substring(url.lastIndexOf('/') + 1);
const groupId = lastSeg.substring(0, 10);

//build signalr connection 
const connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

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
    const response = await fetch(`/api/messages/${groupId}`);
    const data = await response.json();

    //load chatmessages
    data.forEach((element) => {
        if (element["username"]) {
            chat.appendChild(new Message(element["message"], (element["createdAt"].split('T')[1]).slice(0, 8), element["username"]));
        } else {
            chat.appendChild(new SenderMessage(element["message"], (element["createdAt"].split('T')[1]).slice(0, 8)));
        }
    });

    //join hub
    connection.invoke("Join", groupId).catch(function (err) {
        return console.error(err.toString());
    });

//catch if fails
}).catch(function (err) {
    return console.error(err.toString());
});

//Send message
document.getElementById("sendButton").addEventListener("click", function (event) {    
    const message = document.getElementById("messageInput").value;
    if (isEmptyOrSpaces(message)) return;
    connection.invoke("SendMessage", message, groupId).catch(function (err) {
        return console.error(err.toString());
    });
    document.getElementById("messageInput").value = "";

    event.preventDefault();
});

function isEmptyOrSpaces(str) {
    return str === null || str.match(/^ *$/) !== null;
}
