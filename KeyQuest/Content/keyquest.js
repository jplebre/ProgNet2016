﻿function report(elementId, message) {
    var element = document.createElement('p');
    var parent = document.getElementById(elementId);
    parent.appendChild(element);
    element.innerHTML = message;
};

function gameOver(message) {
    var element = document.createElement('div');
    element.className = "game-over";
    document.body.appendChild(element);
    element.innerHTML = "<h2>GAME OVER!</h2>" + message;
}

function victory(message) {
    var element = document.createElement('div');
    element.className = "victory";
    document.body.appendChild(element);
    element.innerHTML = "<h2>YOU HAVE WON!</h2>" + message;
}

function questify(url, elementId) {
    return (function (item) {
        var promise = new Promise(function (resolve, reject) {
            var request = new XMLHttpRequest();
            //Send the proper header information along with the request
            request.open('POST', url);
            request.setRequestHeader("Content-type", "application/json");
            request.setRequestHeader("Accept", "application/json");
            request.onload = function () {
                if (request.status == 200) {
                    var result = JSON.parse(request.response);
                    report(elementId, result.text);
                    resolve(result.item); // we got data here, so resolve the Promise
                } else {
                    reject(Error(request.statusText)); // status is not 200 OK, so reject
                }
            };

            request.onerror = function () {
                reject(Error('Error fetching data.')); // error occurred, reject the  Promise
            };
            request.send(JSON.stringify(item)); //send the request
        });
        return (promise);
    });
}

function runQuest() {
    //TODO: extend this runQuest method to complete all three quests and retrieve all three keys.
    var talkToTheKnight = questify("/knight", "ctrl-div");
    var talkToTheCleric = questify("/cleric", "alt-div");
    var talkToCartman = questify("/cartman", "delete-div");
    var talkToTheWizard = questify("/wizard", "ctrl-div");
    var talkToTheWeaver = questify("/weaver", "ctrl-div");
    var talkToTheEarlLang = questify("/earl", "delete-div");
    var talkToTheBlacksmith = questify("/keysmith", "alt-div");

    var bagOfGold = { name: "Bag Of Gold" };

    var p1 = talkToTheWeaver()
                .then(talkToTheKnight)
                .then(talkToTheWizard);

    var p2 = talkToTheBlacksmith(bagOfGold)
                .then(talkToTheCleric);

    var p3 = talkToCartman(bagOfGold)
                .then(talkToTheEarlLang);

    Promise.all([p1, p2, p3]).then(function (values) {
        console.log("YOU WON!!");
        victory("YOU WON!");
    }).catch(gameOver);
}
