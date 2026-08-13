using System.Text;
namespace Quaq.Services.Sistema;
public class UiService
{
    public static int LarguraTerminal(string texto)
    {
        int largura = 0;

        foreach (var rune in texto.EnumerateRunes())
        {
            largura += LarguraRune(rune);
        }

        return largura;
    }

    private static int LarguraRune(Rune rune)
    {
        int v = rune.Value;

        if (
            // Hangul Jamo
            (v >= 0x1100 && v <= 0x115F) ||

            // CJK Radicals / Kangxi / Ideographs
            (v >= 0x2E80 && v <= 0x2EF3) ||
            (v >= 0x2F00 && v <= 0x2FD5) ||

            // CJK / Hiragana / Katakana / Bopomofo
            (v >= 0x3000 && v <= 0x303E) ||
            (v >= 0x3041 && v <= 0x30FF) ||
            (v >= 0x3105 && v <= 0x3247) ||
            (v >= 0x3250 && v <= 0x4DBF) ||
            (v >= 0x4E00 && v <= 0x9FFF) ||

            // Yi
            (v >= 0xA000 && v <= 0xA4C6) ||

            // Hangul
            (v >= 0xAC00 && v <= 0xD7A3) ||

            // CJK Compatibility
            (v >= 0xF900 && v <= 0xFAFF) ||

            // CJK punctuation / vertical forms
            (v >= 0xFE10 && v <= 0xFE6B) ||

            // Fullwidth
            (v >= 0xFF01 && v <= 0xFF60) ||
            (v >= 0xFFE0 && v <= 0xFFE6) ||

            // CJK Extensions
            (v >= 0x20000 && v <= 0x2FFFD) ||
            (v >= 0x30000 && v <= 0x3FFFD) ||

            // Emoji
            (v >= 0x1F300 && v <= 0x1FAFF)
        )
        {
            return 2;
        }

        return 1;
    }

    public static void Multilinha(int maiorTamanho, string texto)
    {
        int largura = Console.WindowWidth - 4;

        var linha = new StringBuilder();
        int larguraLinha = 0;

        foreach (var rune in texto.EnumerateRunes())
        {
            int larguraRune = LarguraRune(rune);

            if (larguraLinha + larguraRune > largura)
            {
                ImprimirLinha(linha.ToString(), maiorTamanho);
                linha.Clear();
                larguraLinha = 0;
            }

            linha.Append(rune.ToString());
            larguraLinha += larguraRune;
        }

        ImprimirLinha(linha.ToString(), maiorTamanho);
    }

    private static void ImprimirLinha(string texto, int maiorTamanho)
    {
        int larguraTexto = LarguraTerminal(texto);
        int espacos = maiorTamanho - larguraTexto;

        Console.WriteLine(
            $"│ {texto}{new string(' ', Math.Max(0, espacos))} │"
        );
    }

    public static void LinhaUi(string titulo, string texto)
    {
        int larguraTitulo = LarguraTerminal(titulo);
        int larguraTexto = LarguraTerminal(texto);

        int maior = Math.Max(larguraTitulo, larguraTexto);
        int largura = Console.WindowWidth - 4;

        maior = Math.Min(maior, largura);

        int tamanhoBorda = maior - larguraTitulo + 1;

        Console.WriteLine(
            $"┌─{titulo}{new string('─', Math.Max(0, tamanhoBorda))}┐"
        );

        Multilinha(maior, texto);

        Console.WriteLine(
            $"└{new string('─', maior + 2)}┘"
        );
    }

    public static void LinhaUi(string texto)
    {
        int largura = LarguraTerminal(texto);

        Console.WriteLine(
            $"┌{new string('─', largura + 2)}┐"
        );

        Console.WriteLine(
            $"│ {texto} │"
        );

        Console.WriteLine(
            $"└{new string('─', largura + 2)}┘"
        );
    }

    public static void AvisoUi(string texto)
    {
        LinhaUi("Aviso", texto);
    }

    public static void ErroUi(string texto)
    {
        LinhaUi("Erro", texto);
    }

    internal static void ListaUi(string titulo, string[] linhas)
    {
        int maior = LarguraTerminal(titulo);

        foreach (var linha in linhas)
        {
            maior = Math.Max(maior, LarguraTerminal(linha));
        }

        Console.WriteLine(
            $"┌─{titulo}{new string('─', maior - LarguraTerminal(titulo) + 1)}┐"
        );

        foreach (var linha in linhas)
        {
            int larguraLinha = LarguraTerminal(linha);

            Console.WriteLine(
                $"│ {linha}{new string(' ', maior - larguraLinha)} │"
            );
        }

        Console.WriteLine(
            $"└{new string('─', maior + 2)}┘"
        );
    }
}