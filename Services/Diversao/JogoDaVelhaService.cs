namespace Quaq.Services.Diversao;
public class JogoDaVelhaService
{

    public static void Titulo(string texto)
    {
        Console.Clear();

        Console.WriteLine(new string('#', texto.Length + 4));
        Console.WriteLine($"# {texto} #");
        Console.WriteLine(new string('#', texto.Length + 4));
    }
    static bool VerificarVitoria(string[,] tabuleiro, string jogador)
    {
        // Linhas
        if (tabuleiro[0,0] == jogador && tabuleiro[0,1] == jogador && tabuleiro[0,2] == jogador)
            return true;

        if (tabuleiro[1,0] == jogador && tabuleiro[1,1] == jogador && tabuleiro[1,2] == jogador)
            return true;

        if (tabuleiro[2,0] == jogador && tabuleiro[2,1] == jogador && tabuleiro[2,2] == jogador)
            return true;


        // Colunas
        if (tabuleiro[0,0] == jogador && tabuleiro[1,0] == jogador && tabuleiro[2,0] == jogador)
            return true;

        if (tabuleiro[0,1] == jogador && tabuleiro[1,1] == jogador && tabuleiro[2,1] == jogador)
            return true;

        if (tabuleiro[0,2] == jogador && tabuleiro[1,2] == jogador && tabuleiro[2,2] == jogador)
            return true;


        // Diagonal principal
        if (tabuleiro[0,0] == jogador && tabuleiro[1,1] == jogador && tabuleiro[2,2] == jogador)
            return true;


        // Diagonal secundária
        if (tabuleiro[0,2] == jogador && tabuleiro[1,1] == jogador && tabuleiro[2,0] == jogador)
            return true;


        return false;
    }

    public static void Start()
    {
        bool vez = Random.Shared.Next(0, 2) == 1;
        int jogadas = 0;

        string[,] tabuleiro =
        {
            { "1", "2", "3" },
            { "4", "5", "6" },
            { "7", "8", "9" }
        };

        while (true)
        {
            Titulo("Jogo Da Velha");

            Console.WriteLine($"{tabuleiro[0,0]} | {tabuleiro[0,1]} | {tabuleiro[0,2]}");
            Console.WriteLine("---+---+---");
            Console.WriteLine($"{tabuleiro[1,0]} | {tabuleiro[1,1]} | {tabuleiro[1,2]}");
            Console.WriteLine("---+---+---");
            Console.WriteLine($"{tabuleiro[2,0]} | {tabuleiro[2,1]} | {tabuleiro[2,2]}");
            Console.WriteLine();

            string jogador = vez ? "O" : "X";

            Console.WriteLine($"Vez do jogador {jogador}");
            Console.Write("Escolha uma casa (1-9): ");

            string? entrada = Console.ReadLine();

            if (!int.TryParse(entrada, out int posicao) || posicao < 1 || posicao > 9)
            {
                Console.WriteLine("\nPosição inválida!");
                Console.ReadKey();
                continue;
            }

            int linha = (posicao - 1) / 3;
            int coluna = (posicao - 1) % 3;

            // Casa ocupada
            if (tabuleiro[linha, coluna] == "X" || tabuleiro[linha, coluna] == "O")
            {
                Console.WriteLine("\nEssa casa já está ocupada!");
                Console.ReadKey();
                continue;
            }

            tabuleiro[linha, coluna] = jogador;
            jogadas++;

            if (VerificarVitoria(tabuleiro, jogador))
            {
                Titulo("🎉 VITÓRIA! 🎉");

                Console.WriteLine();
                Console.WriteLine("*****************************");
                Console.WriteLine($"   PARABÉNS JOGADOR {jogador}");
                Console.WriteLine("        VOCÊ VENCEU!");
                Console.WriteLine("*****************************");
                Console.WriteLine();

                Console.WriteLine($"{tabuleiro[0,0]} | {tabuleiro[0,1]} | {tabuleiro[0,2]}");
                Console.WriteLine("---+---+---");
                Console.WriteLine($"{tabuleiro[1,0]} | {tabuleiro[1,1]} | {tabuleiro[1,2]}");
                Console.WriteLine("---+---+---");
                Console.WriteLine($"{tabuleiro[2,0]} | {tabuleiro[2,1]} | {tabuleiro[2,2]}");

                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla...");
                Console.ReadKey();
                return;
            }

            // Empate
            if (jogadas == 9)
            {
                Titulo("EMPATE");

                Console.WriteLine("Ninguém venceu desta vez.");

                Console.WriteLine();
                Console.WriteLine($"{tabuleiro[0,0]} | {tabuleiro[0,1]} | {tabuleiro[0,2]}");
                Console.WriteLine("---+---+---");
                Console.WriteLine($"{tabuleiro[1,0]} | {tabuleiro[1,1]} | {tabuleiro[1,2]}");
                Console.WriteLine("---+---+---");
                Console.WriteLine($"{tabuleiro[2,0]} | {tabuleiro[2,1]} | {tabuleiro[2,2]}");

                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla...");
                Console.ReadKey();
                return;
            }

            vez = !vez;
        }
    }
}

