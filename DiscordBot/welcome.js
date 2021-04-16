module.exports = client => {

   const channelId = '785609032403517491';

    client.on('guildMemberAdd', member => {
        console.log(member);

        const message = `Welcome homo <@${member.id}> tänne servulle!`;
        const channel = member.guild.channels.cache.get(channelId);
        channel.send(message);
    })
}
