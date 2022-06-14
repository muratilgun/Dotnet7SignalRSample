﻿//create connection
var connectionUDeathlyHallows = new signalR.HubConnectionBuilder()
//.configureLogging(signalR.LogLevel.Information)
    .withUrl("/hubs/deathyhallows").build();

//connect to methods that hub invokes aka receive notfications from hub
connectionUDeathlyHallows.on("updateDeathlyHallowCount",(cloak,stone,wand) => {
    var newCountSpan = document.getElementById("totalViewsCounter");
    newCountSpan.innerText = value.toString();
});

connectionUserCount.on("updateTotalUsers", (value) => {
    var newCountSpan = document.getElementById("totalUsersCounter");
    newCountSpan.innerText = value.toString();
});

//invoke hub methods aka send notification to hub
function newWindowLoadedOnClient() {
    connectionUserCount.invoke("NewWindowLoaded","Murat").then((value)=> console.log(value));
}

//start connection
function fulfilled() {
    // do something on start
    console.log("Connection to User Hub Successful");
    newWindowLoadedOnClient();
}

function rejected() {
    //rejected logs
}

connectionUserCount.start().then(fulfilled,rejected);
