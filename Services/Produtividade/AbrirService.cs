using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Quaq.Data;
using Quaq.Repository;
using Quaq.Services.Sistema;
using Spectre.Console;

namespace Quaq.Services.Produtividade
{
    public class AbrirService
    {
        static AppRepository repos = new("apps.json");

        public static void Salvar(string nome, string raiz, string? comando)
        {
            if(raiz is null)
            {
                UiService.ErroUi("Raiz não informada.");
                return;
            }
            repos.SalvarJsonApp(nome, new Comando(raiz,comando));
        }

        public static void Abrir(string nome)
        {
            if(nome is null)
            {
                UiService.ErroUi("Nome não informada.");
                return;
            }
            var comando = repos.ExibirComando(nome);
            if(comando is null) return;
            var processo = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = comando.Raiz,
                    Arguments = comando.Args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };
            UiService.OkUi("Abrindo...");
            processo.Start();

            _ = processo.StandardOutput.ReadToEndAsync();
            _ = processo.StandardError.ReadToEndAsync();

        }

        public static void Lista()
        {
            var apps = repos.BuscarTodosApps();
            var opcao = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[bold]Selecione uma tarefa:[/]")
                .AddChoices(apps
                    .Select(x => x.Key)
                    .ToArray()));
            
            Abrir( opcao);
        
        }

        internal static void Deletar(string nome)
        {
            var apps = repos.BuscarTodosApps();
            if(apps.ContainsKey(nome))
            {
                UiService.AvisoUi("app encontrado, quer mesmo deletar (y/n)");
                ConsoleKeyInfo tecla = Console.ReadKey();

                if (tecla.Key == ConsoleKey.Y)
                {
                    apps.Remove(nome);
                    UiService.OkUi("\nDeletado com sucesso");
                }
                else
                {
                    UiService.OkUi("\nCancelado.");
                }
                
                

            }
            repos.SalvarJsonContato(apps);
        }
    }
}