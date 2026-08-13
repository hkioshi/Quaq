using System.CommandLine;
using Quaq.Services.Produtividade;
using Quaq.Interfaces;

namespace Quaq.Commands;

public class PomodoroCommand : IComando
{
    private static Command CriarLongoCommand()
    {
        var cmd = new Command("longo", "Pomodoro longo");
        cmd.SetAction(_ => PomodoroService.Start(3000, 600));
        return cmd;
    }
    private static Command CriarCurtoCommand()
    {
        var cmd = new Command("curto", "Pomodoro curto");
        cmd.SetAction(_ => PomodoroService.Start(1500, 300));
        return cmd;
    }
    public Command Get() =>
        new Command("pomodoro", "Contador de Pomodoro")
        {
            CriarLongoCommand(),
            CriarCurtoCommand()
        };
}
