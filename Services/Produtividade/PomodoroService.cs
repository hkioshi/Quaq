using System.Diagnostics;
using Quaq.Services.Sistema;

namespace Quaq.Services.Produtividade;

enum Estado
{
    Foco,
    Descanso
}

public class PomodoroService
{
    int minutos;
    int segundos;
    Estado estado;
    int Ciclo;
    int TempoDescanso;
    int TempoDescansoLongo 
    {
        get => TempoDescanso * 3;
    }
    int TempoFoco;

    public PomodoroService(int foco, int descanso)
    {
        TempoDescanso = descanso;
        TempoFoco = foco;
        Ciclo = 1;
        estado = Estado.Foco;
    }


    public void Start()
    {
        Console.WriteLine("Foco iniciado!");
        var psi = new ProcessStartInfo
        {
            FileName = "notify-send",
            Arguments = "\"Quaq Timer\" \"Tempo acabou!\"",
            UseShellExecute = false
        };
        while(true)
        {
            IniciarRelogio(TempoFoco, "Foco", psi);
            IniciarRelogio(Ciclo % 4 == 0? TempoDescanso: TempoDescansoLongo, "Descanso", psi);
            Ciclo++;
        }
    }

    private void IniciarRelogio(int Tempo, string Estado,ProcessStartInfo psi )
    {
        
        for (int i = Tempo; i >= 0; i--)
        {
            Console.Clear();
            
            minutos = i / 60;
            segundos = i % 60;
            AtualizarLayout(Ciclo,Estado,$"{minutos:D2}:{segundos:D2}");
   

            Thread.Sleep(1000);
        }
        UiService.AvisoUi($"Fim do {Estado} - Aperte qqr botao pra continuar.");
        Process.Start(psi);
        estado = (Estado)(((int)estado + 1) % 2);
        Console.ReadKey();  
        
    }

    private void AtualizarLayout(int ciclo, string est, string tempo)
    {
        
    }
}
   
