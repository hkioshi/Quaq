using System.Diagnostics;
using Quaq.Services.Media;
using Quaq.Services.Sistema;

namespace Quaq.Services.Produtividade;

public class PomodoroService
{

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
                
                int minutos = i / 60;
                int segundos = i % 60;
                UiService.ListaUi("Pomodoro",[
                    $"Ciclo: {Ciclo}",
                    $"Foco: {minutos:D2}:{segundos:D2}"
                    ]);

                Thread.Sleep(1000);
            }
            UiService.AvisoUi("Fim do Foco - Aperte qqr botao pra continuar.");
            Process.Start(psi);

            Console.ReadKey();    

            TempoDescanso = Ciclo % 4 == 0? TempoDescansoPadrao*3 : TempoDescansoPadrao; 
            for (int i = TempoDescanso; i >= 0; i--)
            {
                Console.Clear();
                 int minutos = i / 60;
                int segundos = i % 60;
                UiService.ListaUi("Pomodoro",[
                    $"Ciclo: {Ciclo}",
                    $"Descanso: {minutos:D2}:{segundos:D2}"
                    ]);

                Thread.Sleep(1000);
                
            }
            UiService.AvisoUi("Fim do descanso - Aperte qqr botao pra continuar.");
            Process.Start(psi);

            Console.ReadKey();     

            Ciclo++;

        }
    }
   
}
