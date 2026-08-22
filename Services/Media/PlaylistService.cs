using Quaq.Services.Sistema;
using Spectre.Console;

namespace Quaq.Services.Media;

public class PlaylistService
{
    
    public static void Tocar()
    {
        string pastaMusicas = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
        $"Músicas"
        );

        Console.WriteLine(pastaMusicas);

        List<string> playlists = [];

        foreach (string pasta in Directory.GetDirectories(pastaMusicas))
        {
            string nomePlaylist = Path.GetFileName(pasta);
            playlists.Add(nomePlaylist);
        }
            
        playlists.Add("[green]Nova Playlist[/]");
        var opcao = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("[bold]Selecione uma playlist:[/]")
            .AddChoices(playlists));
        
        string playlist = "";
        if(opcao.Equals("[green]Nova Playlist[/]"))
        {
            playlist = AnsiConsole.Prompt(
                new TextPrompt<string>("Nome da playlist")
                    .DefaultValue("mix"));
        }
        else
            playlist = opcao;

        bool shuffle = false;
        UiService.OkUi("contato encontrado, quer mesmo deletar (y/n)");
        ConsoleKeyInfo tecla = Console.ReadKey();

        if (tecla.Key == ConsoleKey.Y)
        {
            shuffle = true;
        }
      

        pastaMusicas = Path.Combine(pastaMusicas, playlist);

        if(!Directory.Exists(pastaMusicas))
        {
            UiService.ErroUi($"{pastaMusicas} não existe");
            return;
        }
        var service = new AudioService();
        service.PlayPlaylist(pastaMusicas, shuffle);
    }

}
