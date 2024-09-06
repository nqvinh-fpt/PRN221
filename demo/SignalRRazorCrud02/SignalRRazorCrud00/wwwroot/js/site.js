"use strict";

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/signalRServer")
    .build();

connection.on("LoadCourses", function () {
    location.href='/Courses'
});
connection.start().catch(function (err) {
    return console.error(err.toString());
});