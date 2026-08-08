
using System.CommandLine;
using System.CommandLine.Help;
using Quaq.Services.Desenvolvimento;
using Quaq.Services.Media;
namespace Quaq.Commands
{
    public class QuaqCli 
    {
        
        public RootCommand Get()
        {
            var root = new RootCommand("Quaq - Kit de Utilidades");
            root.Options.Clear();

            root.SetAction(parseResult =>
            {
                ConsoleUI.Home();

                FalaService.Falar(
                    "Olá. Eu sou o Quaq. "
                    + "Digite quaq help"
            );
            });
            root.Add(
                new HelpOption("help", "-h", "--help")
                {
                    Description = "Mostra informações de ajuda"
                });
            root.Add(
                new VersionOption("--version", "-v")
                {
                    Description = "Mostra a versão do quaq"
                });

            return root;
        }
    }
}