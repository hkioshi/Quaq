
using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Diversao;

namespace Quaq.Commands;

public class JogosCommand: IComando
{
    public Command Get() =>
        new Command("jogos", "abre jogos")
        {
            CriarAzaharCommand(),
            CriarSVCommand(),
            CriarModrichCommand()
        };
    private static Command CriarAzaharCommand()
    {
        var cmd = new Command("azahar", "Abre o Azahar");
        cmd.SetAction(_ => JogoService.Abrir("flatpak", "run org.azahar_emu.Azahar"));
        return cmd;
    }
    private static Command CriarSVCommand()
    {
        var cmd = new Command("sv", "Abre o Stardew Valley");
        cmd.SetAction(_ => JogoService.Abrir("steam", "steam://rungameid/413150"));
        return cmd;
    }
    private static Command CriarModrichCommand()
        {
            var cmd = new Command("mod", "Abre o modrich");
            cmd.SetAction(_ =>JogoService.Abrir("flatpak", "run com.modrinth.ModrinthApp"));
            return cmd;
        }

}