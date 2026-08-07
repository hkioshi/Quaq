using System.Diagnostics;

namespace Quaq.Services.Sistema;
public class UpdateService
{
    public static void Update()
    {
        string caminho = "/home/henrique/repos/Projetos_Pessoais/Quaq";

        var processo = new Process();

        processo.StartInfo = new ProcessStartInfo
        {
            FileName = "/bin/bash",
            Arguments = "install.sh",
            WorkingDirectory = caminho,
            UseShellExecute = true
        };

        processo.Start();

        Console.WriteLine("Atualização iniciada.");
        Console.WriteLine("O Quaq será encerrado.");

        Environment.Exit(0);
    }
}