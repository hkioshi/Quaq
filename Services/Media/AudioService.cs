using System.Diagnostics;

namespace Quaq.Services.Media;

public class AudioService
{
    private Process? player;

    bool tocando = true;

    public  void PlayPlaylist(string caminho)
    {
        var musicas = Directory.GetFiles(caminho, "*.mp3")
            .OrderBy(x => x)
            .ToList();

        if (musicas.Count == 0)
        {
            Console.WriteLine("Nenhuma música encontrada.");
            return;
        }

        int atual = 0;

        void Tocar()
        {
            Stop();

            Console.Clear();

            Console.WriteLine($"🎵 {Path.GetFileName(musicas[atual])}");
            Console.WriteLine();
            Console.WriteLine("← Voltar | → Próxima | S Sair | P Pausar");


            player = new Process();

            player.StartInfo.FileName = "ffplay";
            player.StartInfo.Arguments =
                $"-nodisp -autoexit -loglevel quiet \"{musicas[atual]}\"";

            player.StartInfo.UseShellExecute = false;
            player.StartInfo.CreateNoWindow = true;

            player.EnableRaisingEvents = true;

            player.Exited += (s, e) =>
            {
                if (atual < musicas.Count - 1)
                {
                    atual++;
                    Tocar();
                }
                else
                {
                    Console.WriteLine("\nFim da playlist.");
                }
            };

            player.Start();
        }


        Console.CancelKeyPress += (s, e) =>
        {
            e.Cancel = true;
            Stop();
            Environment.Exit(0);
        };


        Tocar();


        while (true)
        {
            var tecla = Console.ReadKey(true);

            switch (tecla.Key)
            {
                case ConsoleKey.LeftArrow:

                    if (atual > 0)
                    {
                        atual--;
                        Tocar();
                    }

                    break;


                case ConsoleKey.RightArrow:

                    if (atual < musicas.Count - 1)
                    {
                        atual++;
                        Tocar();
                    }

                    break;


                case ConsoleKey.P:
                    if(tocando)
                    {
                        Stop();
                        tocando = !tocando;
                    }
                    break;

                case ConsoleKey.C:
                    if(!tocando)
                    {
                        Tocar();
                        tocando = !tocando;
                    }
                break;
                case ConsoleKey.S:

                    Stop();
                    return;
            }
        }
    }


    private void Stop()
    {
        if (player != null)
        {
            if (!player.HasExited)
                player.Kill();
            
            Console.Clear();
            Console.WriteLine("Nenhuma musica tocando");
            Console.WriteLine();
            Console.WriteLine("← Voltar | → Próxima | S Sair | C Começar");
    
            player.Dispose();
            player = null;
        }
    }
}