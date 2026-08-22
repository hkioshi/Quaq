using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Desenvolvimento;

namespace Quaq.Commands;

public class CodarCommand : IComando
{
    public Command Get()
    {
        var CodarCmd = new Command("codar", "Abre o vs code de um projeto salvo");
        

        CodarCmd.SetAction( _ => 
        {
            new ProjetoService().CodarProjeto();
        });

        return CodarCmd;
    }
}
