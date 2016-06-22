function tell(elementId, tale) {
    var element = document.createElement('p');
    var parent = document.getElementById(elementId);
    parent.appendChild(element);
    element.innerHTML = tale;
};

function gameOver(tale) {
    var element = document.createElement('div');
    element.className = "game-over";
    document.body.appendChild(element);
    element.innerHTML = "<h2>GAME OVER!</h2>" + tale;
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
                    tell(elementId, result.text);
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
    var controlKeyQuest = questify("/weaver", "ctrl-div")()
        .then(questify("/knight", "ctrl-div"))
        .then(questify("/wizard", "ctrl-div"));

    var bagOfGold = { name: "Big Bag of Gold" };
    var altKeyQuest = questify("/keysmith", "alt-div")(bagOfGold)
        .then(questify("/cleric", "alt-div"));
    ;
    var diamond = { name: "Emerald of Multiple Inheritance" };
    var deleteKeyQuest = questify("/earl", "delete-div")(diamond);



    Promise.all([controlKeyQuest, altKeyQuest, deleteKeyQuest])
        .then(function (values) {
            //todo: something cool using the three keys to the Kingdom of Winderos.
            if (values.length == 3) {
                victory('You have retrieved the Three Keys to the Kingdom of Winderos. Which is nice.');
            }
        }).catch(gameOver);;
}