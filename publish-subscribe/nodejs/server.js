var express = require('express');
var app = express();
var http = require('http').Server(app);
var io = require('socket.io')(http);

var api = require('./api_queue.js').setIo(io);

app.get('/', function (req, res) {
    res.sendFile(__dirname + '/index.html');
});
app.use('/app', express.static('app'));

http.listen(3000, function () {
    console.log('listening on *:3000');
});