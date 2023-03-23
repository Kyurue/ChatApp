var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

document.getElementById("ChatElement").addEventListener("click", function (event) {
    var ChatName = document.getElementById("ChatName").value;
    connection.invoke("Join", ChatName).catch(function (err) {
        return console.error(err.toString());
    });
    window.location.href = '/home/chat';
});