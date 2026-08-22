using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Media;

namespace Quaq.Commands;

public class PlaylistCommand : IComando
{
    public Command Get()
    {

        
        var PlCmd = new Command("playlist", "Playlist");

        PlCmd.SetAction(parseResult =>
        {
            
                PlaylistService.Tocar();
        });

    return PlCmd;
    }
}
