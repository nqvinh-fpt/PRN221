"use strict";

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/signalRServer")
    .build();

connection.on("LoadEvents", function () {
    location.href = '/Events'
});
connection.start().catch(function (err) {
    return console.error(err.toString());
});