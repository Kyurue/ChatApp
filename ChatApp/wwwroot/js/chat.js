"use strict";
import { template } from "/js/modules/template.js";
import { Message } from "/js/components/message.js";
import { SenderMessage } from "/js/components/senderMessage.js";


//attach templates
template.attachTemplates();
const chat = document.getElementById("chat");
myArray.forEach((element) => {
    if (element.userId) {
        chat.appendChild(new Message(element.message, element.time.split(' ')[1], element.userId));
    } else {
        chat.appendChild(new SenderMessage(element.message, element.time.split(' ')[1], element.userId));
    }
});




//build connection 
const connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//disable button temporarily
document.getElementById("sendButton").disabled = true;

//receive message
connection.on("ReceiveMessage", function (message, time, user = null) {
    if (user) {
        chat.appendChild(new Message(`${message}`, `${time.split(' ')[1]}`, `${user}`));
    } else {
        chat.appendChild(new SenderMessage(`${message}`, `${time.split(' ')[1]}`));
    }
});

//if connection is ready
connection.start().then(function () {
    //enable send button
    document.getElementById("sendButton").disabled = false;

    //join group -> Might change this to backend
    //Need to find a way to get the groupId based on the database value (Viewbag?)
    //connection.invoke("Join", groupId).catch(function (err) {
    //    return console.error(err.toString());
    //});

//catch if fails
}).catch(function (err) {
    return console.error(err.toString());
});

//Send message
document.getElementById("sendButton").addEventListener("click", function (event) {
    //Get message
    const message = document.getElementById("messageInput").value;
    //Send message and groupId, again I need to find a proper way of getting the groupId
    //connection.invoke("SendMessage", message, groupId).catch(function (err) {
    //    return console.error(err.toString());
    //});

    event.preventDefault();
});
