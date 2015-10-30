var amqp = require('amqplib/callback_api');

var io;
exports.setIo = function (io_) {
    io = io_;
};

amqp.connect('amqp://localhost/techmq', function (err, connection) {
    connection.createChannel(function (err, channel) {
        var queueName = 'ps-messages';

        channel.assertQueue(queueName, { durable: true });
        channel.consume(queueName, function (messageContext) {
            var content = JSON.parse(messageContext.content.toString());
            var doAck = false;

            if (messageContext.fields.exchange === 'Common.Messages:DriveToOrder') {
                io.emit('newLocation', { location: content.message.address });
                doAck = true;
            } else {
                console.log(messageContext.fields.exchange);
                console.log(content);
                console.log("----------------------------");
                console.log();
                console.log();
            }

            if (doAck) {
                channel.ack(messageContext);
            }
        });
    });
});