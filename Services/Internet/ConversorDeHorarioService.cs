
using Quaq.Services.Sistema;

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
        ["haiti"] = -5,
        // Europa
        ["islandia"] = 0,
        ["irlanda"] = 0,
        ["reino unido"] = 0,
        ["portugal"] = 0,
        ["espanha"] = 1,
        ["franca"] = 1,
        ["belgica"] = 1,
        ["paises baixos"] = 1,
        ["luxemburgo"] = 1,
        ["suica"] = 1,
        ["italia"] = 1,
        ["alemanha"] = 1,
        ["dinamarca"] = 1,
        ["noruega"] = 1,
        ["suecia"] = 1,
        ["finlandia"] = 2,
        ["estonia"] = 2,
        ["letonia"] = 2,
        ["lituania"] = 2,
        ["polonia"] = 1,
        ["republica tcheca"] = 1,
        ["eslovaquia"] = 1,
        ["austria"] = 1,
        ["hungria"] = 1,
        ["eslovenia"] = 1,
        ["croacia"] = 1,
        ["bosnia e herzegovina"] = 1,
        ["servia"] = 1,
        ["montenegro"] = 1,
        ["kosovo"] = 1,
        ["macedonia do norte"] = 1,
        ["albania"] = 1,
        ["grecia"] = 2,
        ["bulgaria"] = 2,
        ["romenia"] = 2,
        ["moldavia"] = 2,
        ["ucrania"] = 2,
        ["belarus"] = 3,
        ["russia"] = 3,
        ["malta"] = 1,
        ["chipre"] = 2,
        ["andorra"] = 1,
        ["monaco"] = 1,
        ["liechtenstein"] = 1,
        ["san marino"] = 1,
        ["vaticano"] = 1,

        // America do Norte
        ["canada"] = -5,
        ["estados unidos"] = -5,
        ["bahamas"] = -5,
        ["jamaica"] = -5,
        ["panama"] = -5,
        ["costa rica"] = -6,
        ["nicaragua"] = -6,
        ["honduras"] = -6,
        ["el salvador"] = -6,
        ["guatemala"] = -6,
        ["belize"] = -6,

        // Caribe
        ["antigua e barbuda"] = -4,
        ["barbados"] = -4,
        ["dominica"] = -4,
        ["granada"] = -4,
        ["sao cristovao e nevis"] = -4,
        ["santa lucia"] = -4,
        ["sao vicente e granadinas"] = -4,
        ["trinidad e tobago"] = -4,

        // America do Sul
        ["guiana francesa"] = -3,

        // Africa
        ["marrocos"] = 1,
        ["argelia"] = 1,
        ["tunisia"] = 1,
        ["libia"] = 2,
        ["egito"] = 2,
        ["sudao"] = 2,
        ["sudao do sul"] = 2,
        ["etiopia"] = 3,
        ["eritrea"] = 3,
        ["djibuti"] = 3,
        ["somalia"] = 3,
        ["quenia"] = 3,
        ["tanzania"] = 3,
        ["uganda"] = 3,
        ["ruanda"] = 2,
        ["burundi"] = 2,
        ["republica democratica do congo"] = 1,
        ["republica do congo"] = 1,
        ["gabao"] = 1,
        ["camaroes"] = 1,
        ["republica centro africana"] = 1,
        ["chade"] = 1,
        ["nigeria"] = 1,
        ["niger"] = 1,
        ["benin"] = 1,
        ["togo"] = 0,
        ["ghana"] = 0,
        ["costa do marfim"] = 0,
        ["liberia"] = 0,
        ["serra leoa"] = 0,
        ["guine"] = 0,
        ["guine bissau"] = 0,
        ["gambia"] = 0,
        ["senegal"] = 0,
        ["mali"] = 0,
        ["burkina faso"] = 0,
        ["mauritania"] = 0,
        ["cabo verde"] = -1,
        ["guine equatorial"] = 1,
        ["angola"] = 1,
        ["zambia"] = 2,
        ["zimbabue"] = 2,
        ["malawi"] = 2,
        ["mocambique"] = 2,
        ["namibia"] = 2,
        ["botsuana"] = 2,
        ["africa do sul"] = 2,
        ["lesoto"] = 2,
        ["eswatini"] = 2,
        ["madagascar"] = 3,
        ["mauricio"] = 4,
        ["seychelles"] = 4,
        ["comores"] = 3,

        // Oceania
        ["australia"] = 10,
        ["nova zelandia"] = 12,
        ["fiji"] = 12,
        ["papua nova guine"] = 10,
        ["samoa"] = 13,
        ["tonga"] = 13,
        ["tuvalu"] = 12,
        ["kiribati"] = 12,
        ["vanuatu"] = 11,
        ["ilhas salomao"] = 11,
        ["micronesia"] = 10,
        ["palau"] = 9,
        ["ilhas marshal"] = 12,
        ["nauru"] = 12,

        // America Central e Caribe adicionais
        ["aruba"] = -4,
        ["curacao"] = -4,
        ["guadalupe"] = -4,
        ["martinica"] = -4,
        ["porto rico"] = -4,
        ["ilhas virgens americanas"] = -4,
        ["bermudas"] = -4,
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
            UiService.ErroUi("Formato invalido. Use HH:mm");
            return;
        }

        if (!fusos.ContainsKey(p1) || !fusos.ContainsKey(p2))
        {
            UiService.ErroUi("Pais nao encontrado.");
            return;
        }

        int diferenca = fusos[p2] - fusos[p1];

        TimeOnly resultado = horaConvertida.AddHours(diferenca);

        UiService.LinhaUi("Resultado",$"{p1} {hora} -> {p2} {resultado:HH:mm}");
    }
}
