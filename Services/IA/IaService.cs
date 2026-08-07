using System.Net.Http.Json;
using Quaq.Services.Media;

namespace Quaq.Services.IA;

public static class IaService
{
    private static readonly HttpClient client = new()
    {
        BaseAddress = new Uri("http://localhost:11434")
    };

    private const string SystemPrompt = """
Você é a IA do Quaq.

Sempre responda em português brasileiro.

Você deve ajudar o usuário com programação, produtividade, estudos e utilização do Quaq.

Regras:
- Seja objetivo.
- Explique conceitos de forma didática.
- Priorize exemplos em C#.
- Considere que o usuário utiliza Linux.
- Não invente informações.
- Caso não saiba algo, diga claramente.
""";

    public static async Task Conectar()
    {
        List<Message> historico =
        [
            new()
            {
                Role = "system",
                Content = SystemPrompt
            }
        ];

        Console.WriteLine("IA do Quaq");
        Console.WriteLine("Digite /exit para sair.\n");

        while (true)
        {
            Console.Write("> ");

            string? pergunta = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(pergunta))
                continue;

            if (pergunta.Equals("/exit", StringComparison.OrdinalIgnoreCase))
                break;

            historico.Add(new Message
            {
                Role = "user",
                Content = pergunta
            });

            var body = new
            {
                model = "qwen2.5:1.5b",
                messages = historico,
                stream = false
            };

            try
            {
                var response = await client.PostAsJsonAsync("/api/chat", body);

                response.EnsureSuccessStatusCode();

                ChatResponse? resposta =
                    await response.Content.ReadFromJsonAsync<ChatResponse>();

                if (resposta is null)
                    continue;

                Console.WriteLine();
                Console.WriteLine(resposta.Message.Content);
                Console.WriteLine();

                historico.Add(resposta.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
    public static async Task FalaConectar()
{
        List<Message> historico =
        [
            new()
            {
                Role = "system",
                Content = SystemPrompt
            }
        ];

        Console.WriteLine("IA do Quaq");
        Console.WriteLine("Digite /exit para sair.\n");

        while (true)
        {
            Console.Write("> ");

            string? pergunta = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(pergunta))
                continue;

            if (pergunta.Equals("/exit", StringComparison.OrdinalIgnoreCase))
                break;

            historico.Add(new Message
            {
                Role = "user",
                Content = pergunta
            });

            var body = new
            {
                model = "qwen2.5:1.5b",
                messages = historico,
                stream = false
            };

            try
            {
                var response = await client.PostAsJsonAsync("/api/chat", body);

                response.EnsureSuccessStatusCode();

                ChatResponse? resposta =
                    await response.Content.ReadFromJsonAsync<ChatResponse>();

                if (resposta is null)
                    continue;

                Console.WriteLine();
                Console.WriteLine(resposta.Message.Content);
                FalaService.Falar(resposta.Message.Content);
                Console.WriteLine();

                historico.Add(resposta.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
    public class Message
    {
        public string Role { get; set; } = "";
        public string Content { get; set; } = "";
    }

    public class ChatResponse
    {
        public Message Message { get; set; } = new();
    }
}