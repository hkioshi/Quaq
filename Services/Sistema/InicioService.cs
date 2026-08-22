using System.Globalization;
using Quaq.Repository;
using Spectre.Console;


namespace Quaq.Services.Sistema;
public static class ConsoleUI
{
    public static void Home()
    {
        Console.Clear();

        Header();
        SystemInfo();
        Footer();
    }

    private static void Header()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.ForegroundColor = ConsoleColor.Cyan;
        ConfigRepository config = new();
        
        var mensagem = $"Bem vindo {config.ExibirNome()}" ?? "   by Quaq Labs";
        AnsiConsole.Write(
    new Align(
        new Markup($"""
        [cyan]Q U A Q[/]
        [cyan]SISTEMA MULTIUSO DE TERMINAL[/]

        [cyan]{mensagem}[/]

        [cyan]╭────────────────────────────────────╮
        │   __                               │
        │ >(o )___      Bem-vindo ao Quaq    │
        │  ( ._> /     ───────────────────   │
        │   `---'       Digite "Quaq help"   │
        │                                    │
        ╰────────────────────────────────────╯[/]
        """),
        HorizontalAlignment.Center
    )
);

        Console.ResetColor();
    }

    private static void SystemInfo()
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;

        double memoriaTotal = 0;
        double memoriaDisponivel = 0;

        foreach (string linha in File.ReadLines("/proc/meminfo"))
        {
            if (linha.StartsWith("MemTotal:"))
            {
                memoriaTotal = ParseKb(linha);
            }
            else if (linha.StartsWith("MemAvailable:"))
            {
                memoriaDisponivel = ParseKb(linha);
            }
        }

        double memoriaUsada = memoriaTotal - memoriaDisponivel;
        double memoriaTotalGb = memoriaTotal / 1024 / 1024;
        double memoriaUsadaGb = memoriaUsada / 1024 / 1024;
        double usoMemoria = memoriaUsada / memoriaTotal * 100;
        double? temperatura = ObterTemperatura();
        string temperaturaTexto = temperatura.HasValue
            ? $"{temperatura.Value:F1} °C"
            : "N/D";
        string statusTemperatura = temperatura switch
        {
            null =>  "● N/A   ",
            <= 70 => "● NORMAL",
            <= 85 => "● ELEVAD",
            _ =>     "● ALTA  "
        };

        AnsiConsole.Write(
    new Align(
        new Markup($"""
        [darkcyan]┌─ SISTEMA ────────────────────────┐    ┌─ RECURSOS ───────────────────────┐
        │                                  │    │                                  │
        │  VERSÃO      1.6.7               │    │  MEMÓRIA     {memoriaUsadaGb,4:F1} / {memoriaTotalGb,4:F1} GB      │
        │  RUNTIME     net10.0             │    │  USO         {usoMemoria,5:F1}%              │
        │  PLATAFORMA  Linux               │    │  CPU         {temperaturaTexto,-12}        │
        │  STATUS      ● ONLINE            │    │  STATUS      {statusTemperatura,-15}     │
        │                                  │    │                                  │
        └──────────────────────────────────┘    └──────────────────────────────────┘[/]
        """),
        HorizontalAlignment.Center
    )
);

        Console.ResetColor();
    }

    private static double ParseKb(string linha)
    {
        string[] partes = linha.Split(
            ' ',
            StringSplitOptions.RemoveEmptyEntries
        );

        return double.Parse(
            partes[1],
            CultureInfo.InvariantCulture
        );
    }

    private static double? ObterTemperatura()
    {
        string caminho = "/sys/class/thermal";

        if (!Directory.Exists(caminho))
            return null;

        string[] zonas = Directory.GetDirectories(
            caminho,
            "thermal_zone*"
        );

        foreach (string zona in zonas)
        {
            string arquivo = Path.Combine(zona, "temp");

            if (!File.Exists(arquivo))
                continue;

            try
            {
                string valor = File.ReadAllText(arquivo).Trim();

                if (double.TryParse(
                    valor,
                    NumberStyles.Any,
                    CultureInfo.InvariantCulture,
                    out double temperatura))
                {
                    return temperatura / 1000;
                }
            }
            catch
            {
                // Ignora sensores que não puderem ser lidos.
            }
        }

        return null;
    }
        

    private static void Footer()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;

        AnsiConsole.Write(
        new Rule());
        AnsiConsole.Write(
            new Align(
            new Markup("[bold cyan]Um terminal. Infinitas possibilidades.[/]"),
            HorizontalAlignment.Center
            ));

        Console.ResetColor();
    }
}