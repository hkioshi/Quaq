using System.Diagnostics;
using Quaq.Services.Sistema;
using Spectre.Console;

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
    bool Parado = false;
    bool Reiniciar = false;
    bool Sair = false;
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
        _ = Task.Run(IniciarComandos);
        while(true)
        {
            if(Reiniciar)
            {
                Ciclo = 0;
                Reiniciar = false;
            }
            if(Sair) return;
            IniciarRelogio(TempoFoco, "Foco", psi);
            IniciarRelogio(Ciclo % 4 == 0? TempoDescanso: TempoDescansoLongo, "Descanso", psi);
            Ciclo++;
        }
    }

    private void IniciarComandos()
    {
        
        while(true)
        {
            var key = Console.ReadKey();
            
            if( key.Key == ConsoleKey.Spacebar)
                Parado = !Parado;
            if( key.Key == ConsoleKey.R)
            Reiniciar = !Reiniciar;
            if( key.Key == ConsoleKey.S)
            {
                Sair = true;
                return;
            }
        }
    }

    private void IniciarRelogio(int Tempo, string Estado,ProcessStartInfo psi )
    {
        int i = Tempo;
        while(i >= 0)
        {
            if(Sair)
                return;
            
            if(Reiniciar)
                return;
            if(!Parado)
            {
                minutos = i / 60;
                segundos = i % 60;
                AtualizarLayout(Ciclo,Estado,$"{minutos:D2}:{segundos:D2}");

                Thread.Sleep(1000);
            i--; 
            }
            
            
        }
        
       UiService.AvisoUi($"Fim do {Estado} - Aperte qqr botao pra continuar.");

        Console.ReadKey();

        Process.Start(psi);

        estado = (Estado)(((int)estado + 1) % 2);
                
    }



    private void AtualizarLayout(int ciclo, string est, string tempo)
    {
        AnsiConsole.Clear();

        var tabela = new Table
        {
            Border = TableBorder.Rounded,
            Expand = true
        };

        tabela.AddColumn(new TableColumn("Pomodoro"));
        tabela.AddColumn(new TableColumn("Controles"));


        tabela.AddRow(
            new Markup($"[bold]Ciclo[/] - {ciclo}"),
             new Markup("Espaço - Pausar/Continuar")
        );

        tabela.AddRow(
            new Markup($"[bold]Estado[/] - {Markup.Escape(est)}"),
            new Markup("R - Reiniciar")
        );

        tabela.AddRow(
            new Markup($"[bold]Tempo[/] - [bold]{Markup.Escape(tempo)}[/]"),
           new Markup("S - Sair")
        );

        AnsiConsole.Write(tabela);
    }
}
   
