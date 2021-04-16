module.exports = {
    name: 'leave',
    description: 'pysäytä botti ja lähde kanavalta',
    async execute(message, args) {
        const voiceChannel = message.member.voice.channel;
 
        if(!voiceChannel) return message.channel.send("Sinun pitää olla äänikanavalla, jotta voit pysäyttää musiikin");
        await voiceChannel.leave();
        await message.channel.send('Lähdetään kanavalta');
 
    }
}