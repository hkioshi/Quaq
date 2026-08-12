using System.Net.Http.Json;
using Quaq.Services.Media;
using Quaq.Services.Sistema;

namespace Quaq.Services.Produtividade;

public class MotivacaoService
{
    static string[] conselhos =
    {
        "Vai trabalhar.",
        "Menos reclamar, mais fazer.",
        "Levanta e começa.",
        "Ninguém vai fazer por você.",
        "Um passo por dia ainda é progresso.",
        "Sai do planejamento e vai para a ação.",
        "Seu futuro depende do que você faz hoje.",
        "Para de esperar o momento perfeito.",
        "Faz agora, melhora depois.",
        "Disciplina vence motivação.",
        "Começa pequeno, mas começa.",
        "O tempo passa de qualquer jeito.",
        "Enquanto você pensa, alguém está fazendo.",
        "Bora produzir.",
        "Foco no objetivo.",
        "Fecha as abas e abre o projeto.",
        "Menos scroll, mais código.",
        "O café acabou, mas a missão continua.",
        "Vai estudar.",
        "Vai treinar.",
        "Vai criar algo.",
        "Vai terminar o que começou.",
        "A preguiça não paga contas.",
        "Sonho sem ação é só ideia.",
        "Hoje é um bom dia para começar.",
        "Faça por você mesmo.",
        "O esforço de hoje é o resultado de amanhã.",
        "Pare de adiar.",
        "A versão futura de você agradece.",
        "Você não precisa estar pronto, precisa começar.",
        "Um commit por dia mantém o caos longe.",
        "Seu projeto não vai terminar sozinho.",
        "Abre o editor e escreve.",
        "Cinco minutos já são melhores que zero.",
        "Faz acontecer.",
        "Continua.",
        "Não desiste agora.",
        "O caminho é longo, mas você está andando.",
        "Erros fazem parte do processo.",
        "Aprenda, ajuste e tente novamente.",
        "O importante é continuar.",
        "Menos desculpas, mais progresso.",
        "Organiza a mesa e começa.",
        "A melhor hora era ontem, a segunda melhor é agora.",
        "Seu computador está ligado, use ele.",
        "Transforme ideias em realidade.",
        "Código não se escreve sozinho.",
        "Projetos nascem de pequenas ações.",
        "Não espere inspiração, crie rotina.",
        "Faça o difícil primeiro.",
        "Termine uma coisa antes de começar outra.",
        "Hoje é dia de avançar."
    };

    public static void Motivar()
    {
        Random random = new Random();
        var conselho = conselhos[random.Next(conselhos.Length)];
        UiService.LinhaUi("Concelho",conselho);
        FalaService.Falar(conselho);
    }
    public static async Task GetAdvice()
    {
        HttpClient httpClient = new();

        AdviceResponse? json = await httpClient.GetFromJsonAsync<AdviceResponse>(
            "https://api.adviceslip.com/advice");

        UiService.LinhaUi("Motivação",json?.slip.advice ?? "Conselho nao encontrado");
    }
}

public class AdviceResponse
{
    public Advice slip { get; set; } = null!;
}

public class Advice
{
    public int id { get; set; }
    public string advice { get; set; } = "";
}


