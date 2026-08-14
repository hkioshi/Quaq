using System.Text;
using Spectre.Console;
namespace Quaq.Services.Sistema;
public class UiService
{

   public static void LinhaUi(string titulo, string texto) =>
    AnsiConsole.Write(
        new Panel(Markup.Escape(texto))
        {
            Header = new PanelHeader(Markup.Escape(titulo))
        }
    );

public static void LinhaUi(string texto) =>
    AnsiConsole.Write(
        new Panel(Markup.Escape(texto))
    );
    public static void OkUi(string texto)=>
        LinhaUi("Ok", $"[green]{texto}[/]");
    public static void AvisoUi(string texto)=>
        LinhaUi("Aviso", $"[yellow]{texto}[/]");

    public static void ErroUi(string texto) =>
        LinhaUi("Erro", $"[red]{texto}[/]");
    

    internal static void ListaUi(string titulo, string[] linhas)
    {
        var table = new Table();

        table.AddColumn(titulo);

        foreach (var linha in linhas)
            table.AddRow(linha);
        AnsiConsole.Write(table);

    }
}