var http = require('http');
var addresses = [];

var api = {
    io: null,
    intervalPointer: null,
    intervalTime: 1000,
    runInterval: function () {
        var self = this;
        http.get('http://localhost:60000/api/address', function (response) {
            var data = "";
            response.on('data', function (d) {
                data += d.toString();
            });
            response.on('end', function () {
                api.addAddresses(JSON.parse(data));
            });
        });
    },
    addAddresses: function (newAddressList) {
        for (var i = 0; i < newAddressList.length; i++) {
            var address = newAddressList[i];
            if (!addresses.some(function(a) {return a == address; })) {
                console.log(address);
                addresses.push(address);
                this.io.emit('newLocation', { location: address });
            }
        }
    },
    setupInterval: function () {
        this.intervalPointer = setInterval(this.runInterval, this.intervalTime);
    }
};

exports.setIo = function (io) {
    api.io = io;
    api.setupInterval();
};