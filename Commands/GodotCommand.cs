using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Desenvolvimento;

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