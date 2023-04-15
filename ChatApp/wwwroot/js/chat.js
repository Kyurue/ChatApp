"use strict";
//build connection 
const connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//disable button temporarily
document.getElementById("sendButton").disabled = true;

//receive message
connection.on("ReceiveMessage", function (message, user = null) {
    if (user) {
        //Add message with user & message on the left side of the chat (receiver pov) or if user = null right side of chat (Sender POV)
        //This method is only for people receiving the message, not for the sender
        //Still need to make js components for this. 
        //add receiver message (message = message, user = user)
    } else {
        //Add message with user & message on the right side of chat (Sender POV)
        //This method is only for people receiving the message, not for the sender
        //Still need to make js components for this. 
        //add sender message (message = message, user = "you")
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
