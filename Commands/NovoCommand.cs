using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Desenvolvimento;
using Quaq.Services.Sistema;

namespace Quaq.Commands;
public class NovoCommand: IComando
{
   
    public Command Get()
    {
        var cmd = new Command("novo", "Criar novos projetos");
        cmd.SetAction(pr => NovoService.NovoMenu());
        return cmd;
    }
}