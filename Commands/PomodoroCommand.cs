using System.CommandLine;
using Quaq.Services.Produtividade;
using Quaq.Interfaces;

namespace Quaq.Commands;

public class PomodoroCommand : IComando
{
    private static Command CriarLongoCommand()
    {
        var cmd = new Command("longo", "Pomodoro longo");
        cmd.SetAction(_ => new PomodoroService(3000, 600).Start());
        return cmd;
    }
    private static Command CriarCurtoCommand()
    {
        var cmd = new Command("curto", "Pomodoro curto");
        cmd.SetAction(_ => new PomodoroService(1500, 300).Start());
        return cmd;
    }
    public Command Get() =>
        new Command("pomodoro", "Contador de Pomodoro")
        {
            CriarLongoCommand(),
            CriarCurtoCommand()
        };
}
