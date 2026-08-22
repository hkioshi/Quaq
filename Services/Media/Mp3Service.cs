using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
using Quaq.Services.Sistema;
using Spectre.Console;
namespace Quaq.Services.Media;
public class Mp3Service
{
    public static void BaixarMp3(string url)
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


        pastaMusicas = Path.Combine(pastaMusicas, playlist);
        Directory.CreateDirectory(pastaMusicas);

        string saida = Path.Combine(
            pastaMusicas,
            "%(title)s.%(ext)s"
        );

        ProcessStartInfo psi = new()
        {
            FileName = "yt-dlp",
            Arguments = $"-x --audio-format mp3 -o \"{saida}\" \"{url}\"",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using Process process = new()
        {
            StartInfo = psi
        };

        process.OutputDataReceived += (s, e) =>
        {
            if (e.Data != null)
                Console.WriteLine(e.Data);
        };

        process.ErrorDataReceived += (s, e) =>
        {
            if (e.Data != null)
                Console.WriteLine($"ERRO: {e.Data}");
        };

        process.Start();

        process.BeginOutputReadLine();
        process.BeginErrorReadLine();

        process.WaitForExit();

        UiService.OkUi("Música salva em: " + pastaMusicas);
    }
}