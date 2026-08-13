using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Media;

namespace Quaq.Commands;

public class BaixarMp3Command : IComando
{
    public Command Get()
    {

        var urlArg = new Argument<string>("url")
        {
            Description = "URL do vídeo a ser baixado"
        };

        var saveArg = new Argument<string>("playlist")
        {
            Description = "Salvar na playlist"
        };
        var mp3Cmd = new Command("baixarmp3", "Baixa vídeos do YouTube como MP3")
        {
            urlArg,
            saveArg
        };

        mp3Cmd.SetAction(pr =>
        {
            var url = pr.GetValue(urlArg);
            var playlist = pr.GetValue(saveArg);
            
            if(url is not null && playlist is not null)
            {
                Mp3Service.BaixarMp3(url, playlist);
            }
                
        });

        

        return mp3Cmd;
    }
}

