
const ytdl = require('ytdl-core');
const ytSearch = require('yt-search');
 
module.exports = {
    name: 'play',
    description: 'Liittyy äänikanavalle ja soittaa videon youtubesta',
    async execute(message, args) {
        const voiceChannel = message.member.voice.channel;
        
        //tarkistaa onko jäsenellä tarvittavat oikeudet ja että komento on kirjoitettu oikeaan muotoon
        if (!voiceChannel) return message.channel.send('Pitää olla äänikanavalle jos haluat käyttää tätä komentoa!');
        const permissions = voiceChannel.permissionsFor(message.client.user);
        if (!permissions.has('CONNECT')) return message.channel.send('Sinulla ei ole tarvittavia oikeuksia!');
        if (!permissions.has('SPEAK')) return message.channel.send('Sinulla ei ole tarvittavia oikeuksia!');
        if (!args.length) return message.channel.send('Tarvitset toisen argumentin!');
        

        //halutaan soittaa URL suoraan, testataan onko käyttäjän antama argumentti oikeasti URL
        const validURL = (str) =>{
            var regex = /(http|https):\/\/(\w+:{0,1}\w*)?(\S+)(:[0-9]+)?(\/|\/([\w#!:.?+=&%!\-\/]))?/;
            if(!regex.test(str)){
                return false;
            } else {
                return true;
            }
        }
 
        if(validURL(args[0])){
 
            const  connection = await voiceChannel.join();
            const stream  = ytdl(args[0], {filter: 'audioonly'});
 
            connection.play(stream, {seek: 0, volume: 1})
            .on('finish', () =>{
                voiceChannel.leave();
                message.channel.send('lähdetään kanavalta');
            });
 
            await message.reply(`Nyt soitetaan ***Antamasi linkki!***`)
 
            return
        }
 
        //botti liittyy äänikanavalle
        const  connection = await voiceChannel.join();
        
        //etsi youtubesta videoita hakusanoilla
        const videoFinder = async (query) => {
            const videoResult = await ytSearch(query);
            
            //jos videoita on enemmän kuin yksi hakusanoilla valitaan ensimmäinen(ylin video) video
            return (videoResult.videos.length > 1) ? videoResult.videos[0] : null;
 
        }
 
        const video = await videoFinder(args.join(' '));
 
        if(video){
            const stream  = ytdl(video.url, {filter: 'audioonly'});  //vain audio -> äänikanavalle
            connection.play(stream, {seek: 0, volume: 1})            //soittaa ääntä
            .on('finish', () =>{ 
                voiceChannel.leave();                                // lähtee soitettuaan biisin
            });
 
            await message.reply(`Nyt soitetaan ***${video.title}***`)
        } else {
            message.channel.send('Videoita ei löytynyt');
        }
    }
}