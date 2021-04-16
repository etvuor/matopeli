const Discord = require('discord.js');
const client = new Discord.Client();
 
const prefix = '!';
 
const fs = require('fs');
 
client.commands = new Discord.Collection();
 
const commandFiles = fs.readdirSync('./commands/').filter(file => file.endsWith('.js'));
for(const file of commandFiles){
    const command = require(`./commands/${file}`);
 
    client.commands.set(command.name, command);
}
 
 
client.once('ready', () => {
    console.log('Test botti on onlinessa!');
});

//botti antaa servulle liittyjille roolin jäsen ja toivottaa heidät tervetulleeksi
client.on('guildMemberAdd', guildMember =>{
    let welcomeRole = guildMember.guild.roles.cache.find(role => role.name === 'jasen');
    guildMember.roles.add(welcomeRole);
    guildMember.guild.channels.cache.get('805774104476647465').send(`Tervetuloa Pehmolehman Discord-servulle <@${guildMember.user.id}>`);
});
 
client.on('message', message =>{
    if(!message.content.startsWith(prefix) || message.author.bot) return;
 
    const args = message.content.slice(prefix.length).split(/ +/);
    const command = args.shift().toLowerCase();
   
    // ping testi-komento testataan miten komennon toimii kun viestikanavalla lähettää ping-komennon pitäisi vastauksen tulla pong
    if(command === 'ping'){
        client.commands.get('ping').execute(message, args);
    } 
    //komento tuo viestikanavalle youtubesta kummelin "apinaa koijataan" biisin
        if(command === 'apina'){
        client.commands.get('apina').execute(message, args);
    } 
    //soittaa laulun botilla äänikanavalla
    if(command === 'play'){
        client.commands.get('play').execute(message, args);
    } 
    //laittaa botin lähtemään äänikanavalta
    if(command === 'stop'){
        client.commands.get('leave').execute(message, args);
    } 
});
  

    


client.login(YourServersLoginInfo);
