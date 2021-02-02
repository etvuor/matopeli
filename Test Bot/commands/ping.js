module.exports = {
    name: 'ping',
    description: 'ping komento',
    execute(message,args){
        message.channel.send('pong!');
    }
}