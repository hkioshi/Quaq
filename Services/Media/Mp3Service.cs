using System.Diagnostics;
namespace Quaq.Services.Media;
public class Mp3Service
{
    public static void BaixarMp3(string url, string playlist)
    {
        string pastaMusicas = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            $"Músicas/{playlist}"
        );

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

        Console.WriteLine("Música salva em: " + pastaMusicas);
    }
}