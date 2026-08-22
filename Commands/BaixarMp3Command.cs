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

        var mp3Cmd = new Command("ymp3", "Baixa vídeos do YouTube como MP3")
        {
            urlArg,
        };

        mp3Cmd.SetAction(pr =>
        {
            var url = pr.GetValue(urlArg);
            if(url is not null )
                Mp3Service.BaixarMp3(url);
        });
        return mp3Cmd;
    }
}

