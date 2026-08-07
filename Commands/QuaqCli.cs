
using System.CommandLine;
using System.CommandLine.Help;
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
                Console.WriteLine("""
                      __
                    >(o )___
                    ( ._> /
                     `---'

                Quaq - Sua Ferramenta Multiuso Cli

                Digite:
                    quaq --help
                """);
                FalaService.Falar("O lá... eu sou quaq. Digite quaq - - help");
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