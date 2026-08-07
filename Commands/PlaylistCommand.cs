using System;
using System.Collections.Generic;
using System.CommandLine;
using System.Linq;
using System.Threading.Tasks;
using Quaq.Commands.Interfaces;
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

            PlCmd.Add(PlArg);

            PlCmd.SetAction(parseResult =>
            {

                var playlist = parseResult.GetValue(PlArg);
                
                if(playlist is not null)
                {
                    PlaylistService.Tocar(playlist);
                }
            });

        return PlCmd;
        }
    }
}