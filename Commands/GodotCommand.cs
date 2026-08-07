using System.CommandLine;
using Quaq.Services.Desenvolvimento;
using Quaq.Commands.Interfaces;

namespace Quaq.Commands;

public class GodotCommand : IComando
{
    public Command Get()
    {
       var GodotCmd = new Command("godot", "abre o godot");
       GodotCmd.SetAction(_ =>
       {
            GodotService.AbrirGodot(); 
       });
       return GodotCmd;
    }
}