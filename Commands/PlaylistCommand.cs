using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Media;

namespace Quaq.Commands
{
    public class PlaylistCommand : IComando
    {
        public Command Get()
        {
            var PlCmd = new Command("playlist", "Playlist");

            var PlArg = new Argument<string>("playlist")
            {
                Description = "Tocar playlist"
            };
        var ShfflOP = new Option<bool>("-a","-s","--aleatorio","--shuffle")
            {
                Description = "Aleatorizar a playlist"
            };


            PlCmd.Add(PlArg);
            PlCmd.Add(ShfflOP);

            PlCmd.SetAction(parseResult =>
            {

                var playlist = parseResult.GetValue(PlArg);
                
                if(playlist is not null)
                {
                    if(parseResult.GetValue(ShfflOP))
                        PlaylistService.Tocar(playlist, true);
                    else
                        PlaylistService.Tocar(playlist, false);
                }
            });

        return PlCmd;
        }
    }
}