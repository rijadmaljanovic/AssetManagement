"use strict";

const connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.on("Message", function (message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodeMsg = " kaze: " + msg;
    var li = document.createElement("li");
    li.textContent = encodeMsg;
    document.getElementById("messageList").appendChild(li);
});

connection.start().then(res => {
    connection.invoke("JoinGroup", "Group")
        .catch(err => {
            console.log(err);
        });
}).catch(err => {
    console.log(err);
});;

connection.onclose(function (e) {
    connection.invoke("LeaveGroup", "Group").catch(function (err) { return console.error(err.toString); });
})

window.onunload = function () {
    connection.invoke("LeaveGroup", "Group").catch(function (err) { return console.error(err.toString); });
}

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("MessageInput").value;
    connection.invoke("SendToGroup", "Group" , message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});