using System.Diagnostics;

namespace Quaq.Services.Produtividade;

public class PomodoroService
{

    public static void Titulo(string texto)
    {
        Console.Clear();

        Console.WriteLine(new string('#', texto.Length + 4));
        Console.WriteLine($"# {texto} #");
        Console.WriteLine(new string('#', texto.Length + 4));
    }
    public static void Start(int foco, int descanso)
    {
        int tempoFoco = foco;
        int TempoDescansoPadrao = descanso;
        int TempoDescanso;
        var psi = new ProcessStartInfo
        {
            FileName = "notify-send",
            Arguments = "\"Quaq Timer\" \"Tempo acabou!\"",
            UseShellExecute = false
        };



        int Ciclo = 1;
        while(true)
        {
            Console.WriteLine("Foco iniciado!");

            for (int i = tempoFoco; i >= 0; i--)
            {
                Console.Clear();
                Titulo("Pomodoro");
                Console.WriteLine($"Ciclo: {Ciclo}");
                int minutos = i / 60;
                int segundos = i % 60;

                Console.WriteLine($"Foco: {minutos:D2}:{segundos:D2}");

                Thread.Sleep(1000);
            }
            Console.WriteLine("Fim do Foco - Aperte qqr botao pra continuar.");
            Process.Start(psi);

            Console.ReadKey();    

            TempoDescanso = Ciclo % 4 == 0? TempoDescansoPadrao*3 : TempoDescansoPadrao; 
            for (int i = TempoDescanso; i >= 0; i--)
            {
                Console.Clear();
                Titulo("Pomodoro");
                Console.WriteLine($"Ciclo: {Ciclo}");
                int minutos = i / 60;
                int segundos = i % 60;

                Console.WriteLine($"Descanso: {minutos:D2}:{segundos:D2}");

                Thread.Sleep(1000);
                
            }
            Console.WriteLine("Fim do descanso - Aperte qqr botao pra continuar.");
            Process.Start(psi);

            Console.ReadKey();     

            Ciclo++;

        }
    }
}
