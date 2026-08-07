using System.CommandLine;
using Quaq.Services.Produtividade;
using Quaq.Commands.Interfaces;

namespace Quaq.Commands;

public class PomodoroCommand : IComando
{
    public Command Get()
    {
        var PomodoroCmd = new Command("pomodoro", "Contador de Pomodoro");
        var pomodoroLongoOp = new Option<bool>("--long", "-l")
        {
            Description = "Inicia um pomodoro longo (50 minutos)"
        };
        var pomodoroCurtoOp = new Option<bool>("--short", "-s")
        {
            Description = "Inicia um pomodoro curto (25 minutos)"
        };

        var TocarPlaylistOp = new Option<string>("-p", "--playlist")
        {
            Description = "Toca Playlist"
        };
        PomodoroCmd.Add(pomodoroLongoOp);
        PomodoroCmd.Add(pomodoroCurtoOp);
        PomodoroCmd.Add(TocarPlaylistOp);

        PomodoroCmd.SetAction(parseResult =>
        {
            var playl = parseResult.GetValue(TocarPlaylistOp);
            
            if (parseResult.GetValue(pomodoroLongoOp))
                if(playl is not null)    
                    PomodoroService.Start(3000, 600, playl);   
                else
                    PomodoroService.Start(3000, 600);
            else if (parseResult.GetValue(pomodoroCurtoOp))
                if(playl is not null)    
                    PomodoroService.Start(1500, 300, playl);   
                else
                PomodoroService.Start(1500, 300);
            else
                Console.WriteLine("Tempo não especificado. Use --long ou --short.");       

         
        });

        return PomodoroCmd;
    }
}
