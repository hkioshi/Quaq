
using System.CommandLine;
using System.CommandLine.Help;
using Quaq.Services.Sistema;
namespace Quaq.Commands;

public static class QuaqCli 
{
    public static RootCommand Get()
    {
        var root = new RootCommand("Quaq - Kit de Utilidades");
        root.Options.Clear();

        root.Add(
            new HelpOption("help", "-h", "--help")
            {
                Description = "Mostra informações de ajuda"
            });
        root.Add(
            new VersionOption("--versao", "-v", "--version")
            {
                Description = "Mostra a versão do quaq"
            });
            
        root.Adicionar(
            new AnotacoesCommand().Get(),
            new AbrirCommand().Get(),
            new BaixarMp3Command().Get(),
            new CaluladoraCommand().Get(),
            new CameraCommand().Get(),
            new CodarCommand().Get(),
            new ConfigCommand().Get(),
            new ContatoCommand().Get(),
            new DadosCommand().Get(),
            new EmailCommand().Get(),
            new FalaCommand().Get(),
            new FraseCommand().Get(),
            new HoraCommand().Get(),
            new IaCommand().Get(),
            new IpCommand().Get(),
            new LogCommand().Get(),
            new NavegacaoCommand().Get(),
            new NovoCommand().Get(),
            new PlaylistCommand().Get(),
            new PomodoroCommand().Get(),
            new ProjetosCommand().Get(),
            new QrCodeCommand().Get(),
            new RodarCommand().Get(),
            new TarefaCommand().Get(),
            new VelhaCommand().Get()
        );
        root.SetAction(_ => ConsoleUI.Home());
        return root;
    }
    private static void Adicionar(
        this RootCommand root, 
        params Command[] comandos)
    {
        foreach(var com in comandos)    
            root.Add(com);
    }

}
