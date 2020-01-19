//const app = require('express');
const server = require('http').createServer();
const io = require('socket.io')(server);
const UserService = require('./services/userService');

const ServerPort = 115;



//Init On Client Connect with listeners
let OnClientConnect = function(socket)
{

    
    console.log("A New User Connected");
    //Init Listeners
    socket.on('LoginRequest',(data) =>{UserService.Login(data,socket)});
    socket.on('disconnect',OnClientDisconnect);


    //Auth Server
    socket.emit('connectSucess');
}

let OnClientDisconnect = function(socket)
{
    console.log("A User Disconnected");
    global.TotalUsers.splice({Session : socket});
    
    


}

//Starts The Listening
console.log("Init Server, Please Wait...");
io.on('connection',OnClientConnect);
server.listen(ServerPort, function (err) {
    if (err) throw (err)
    console.log("Server Online on port", ServerPort);
})