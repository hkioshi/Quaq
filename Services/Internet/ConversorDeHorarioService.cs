
namespace Quaq.Services.Internet;

public class ConversorDeHorarioService
{
    private static Dictionary<string, int> fusos = new()
    {
        // Asia
        ["japao"] = 9,
        ["china"] = 8,
        ["coreia do sul"] = 9,
        ["coreia do norte"] = 9,
        ["india"] = 5,
        ["indonesia"] = 7,
        ["tailandia"] = 7,
        ["vietna"] = 7,
        ["filipinas"] = 8,
        ["malasia"] = 8,
        ["singapura"] = 8,
        ["mianmar"] = 6,
        ["bangladesh"] = 6,
        ["nepal"] = 5,
        ["paquistao"] = 5,
        ["afeganistao"] = 4,
        ["ira"] = 3,
        ["iraque"] = 3,
        ["arabia saudita"] = 3,
        ["emirados arabes unidos"] = 4,
        ["oma"] = 4,
        ["cazaquistao"] = 5,
        ["uzbequistao"] = 5,
        ["turcomenistao"] = 5,
        ["quirguistao"] = 6,
        ["tajiquistao"] = 5,
        ["mongolia"] = 8,
        ["taiwan"] = 8,
        ["jordania"] = 3,
        ["libano"] = 2,
        ["turquia"] = 3,
        ["georgia"] = 4,
        ["armenia"] = 4,
        ["azerbaijao"] = 4,

        // America Latina
        ["brasil"] = -3,
        ["argentina"] = -3,
        ["uruguai"] = -3,
        ["paraguai"] = -4,
        ["chile"] = -4,
        ["bolivia"] = -4,
        ["peru"] = -5,
        ["equador"] = -5,
        ["colombia"] = -5,
        ["venezuela"] = -4,
        ["guiana"] = -4,
        ["suriname"] = -3,
        ["panama"] = -5,
        ["costa rica"] = -6,
        ["nicaragua"] = -6,
        ["honduras"] = -6,
        ["el salvador"] = -6,
        ["guatemala"] = -6,
        ["belize"] = -6,
        ["mexico"] = -6,
        ["cuba"] = -5,
        ["republica dominicana"] = -4,
        ["haiti"] = -5
    };   


    public static void ConverterHora(string p1, string p2, string hora)
    {
        bool valido = TimeOnly.TryParseExact(
            hora,
            "HH:mm",
            out TimeOnly horaConvertida
        );

        if (!valido)
        {
            Console.WriteLine("Formato invalido. Use HH:mm");
            return;
        }

        if (!fusos.ContainsKey(p1) || !fusos.ContainsKey(p2))
        {
            Console.WriteLine("Pais nao encontrado.");
            return;
        }

        int diferenca = fusos[p2] - fusos[p1];

        TimeOnly resultado = horaConvertida.AddHours(diferenca);

        Console.WriteLine($"{p1} {hora} -> {p2} {resultado:HH:mm}");
    }
}
