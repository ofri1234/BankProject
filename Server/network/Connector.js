//const app = require('express');
const server = require('http').createServer();
const io = require('socket.io')(server);
const UserService = require('./services/userService');

const ServerPort = 104;



//Init On Client Connect with listeners
let OnClientConnect = function(socket)
{

    
    console.log("A New User Connected");
    //Init Listeners
    socket.on('LoginRequest',(data) =>{UserService.Login(data,socket)});


    //Auth Server
    socket.emit('connectSucess');
}



//Starts The Listening
console.log("Init Server, Please Wait...");
io.on('connection',OnClientConnect);
server.listen(ServerPort, function (err) {
    if (err) throw (err)
    console.log("Server Online on port", ServerPort);
})