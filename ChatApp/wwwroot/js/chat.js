"use strict";
//build connection 
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//disable button temporarily
document.getElementById("sendButton").disabled = true;

//receive message
connection.on("ReceiveMessage", function (user, message) {
    //Add message with user & message on the left side of the chat (receiver pov)
    //This method is only for people receiving the message, not for the sender
    //Still need to make js components for this. 
});

function Sendmessage(message) {
    //add message on the right side of the chat (sender pov)
    //still need to make js components for this
}

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
    var message = document.getElementById("messageInput").value;
    //Send message and groupId, again I need to find a proper way of getting the groupId
    //connection.invoke("SendMessage", message, groupId).catch(function (err) {
    //    return console.error(err.toString());
    //});

    //send message to sender pov. 
    Sendmessage(message);

    event.preventDefault();
});
