using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Quaq.Services.Sistema;

namespace Quaq.Services.Media
{
    public class PlaylistService
    {
        
        public static void Tocar(string pasta ,bool shuffle)
        {
            string pastaMusicas = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "Músicas",
            pasta);

            if(!Directory.Exists(pastaMusicas))
            {
                UiService.ErroUi($"{pasta} não existe");
                return;
            }
            var service = new AudioService();
            service.PlayPlaylist(pastaMusicas, shuffle);
        }

    }
}