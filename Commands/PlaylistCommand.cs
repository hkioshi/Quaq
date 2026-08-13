using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Media;

namespace Quaq.Commands;

public class PlaylistCommand : IComando
{
    public Command Get()
    {

        var PlArg = new Argument<string>("playlist")
        {
            Description = "Tocar playlist"
        };
        var ShfflOP = new Option<bool>("-a","-s","--aleatorio","--shuffle")
        {
            Description = "Aleatorizar a playlist"
        };

        var PlCmd = new Command("playlist", "Playlist")
        {
            PlArg,
            ShfflOP
        };

        PlCmd.SetAction(parseResult =>
        {
            var playlist = parseResult.GetValue(PlArg);
            
            if(playlist is not null)
                PlaylistService.Tocar(playlist, parseResult.GetValue(ShfflOP));
        });

    return PlCmd;
    }
}
