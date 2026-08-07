using System.CommandLine;
using Quaq.Services.Produtividade;
using Quaq.Commands.Interfaces;

namespace Quaq.Commands;

public class PomodoroCommand : IComando
{
    public Command Get()
    {
        var PomodoroCmd = new Command("pomodoro", "Contador de Pomodoro");
        var pomodoroLongoOp = new Option<bool>("--long", "-l")
        {
            Description = "Inicia um pomodoro longo (50 minutos)"
        };
        var pomodoroCurtoOp = new Option<bool>("--short", "-s")
        {
            Description = "Inicia um pomodoro curto (25 minutos)"
        };
        PomodoroCmd.Add(pomodoroLongoOp);
        PomodoroCmd.Add(pomodoroCurtoOp);
        PomodoroCmd.SetAction(parseResult =>
        {
            if (parseResult.GetValue(pomodoroLongoOp))
                PomodoroService.Start(3000, 600);
            else if (parseResult.GetValue(pomodoroCurtoOp))
                PomodoroService.Start(1500, 300);
            else
                Console.WriteLine("Tempo não especificado. Use --long ou --short.");        
        });

        return PomodoroCmd;
    }
}
