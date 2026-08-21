using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Desenvolvimento;

namespace Quaq.Commands;

public class CodarCommand : IComando
{
    public Command Get()
    {
        var CodarArg = new Argument<string>("Nome do projeto");
        var CodarCmd = new Command("codar", "Abre o vs code de um projeto salvo")
        {
            CodarArg
        };

        CodarCmd.SetAction( pr => 
        {
            new ProjetoService().CodarProjeto(pr.GetValue(CodarArg)!);
        });

        return CodarCmd;
    }
}
