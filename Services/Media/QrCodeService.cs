
using QRCoder;
using Quaq.Services.Sistema;

namespace Quaq.Services.Media;

public class QrCodeService
{
    public static void GerarQrCode(string url)
    {
        Console.Write("Qual o nome do Arquivo?: ");
        var nome = Console.ReadLine();
        byte[] png = PngByteQRCodeHelper.GetQRCode(
        url,
        QRCodeGenerator.ECCLevel.Q,
        20);

        string downloads = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
            "Downloads");

        string caminho = Path.Combine(downloads, $"{nome}.png");

        File.WriteAllBytes(caminho, png);

        UiService.AvisoUi($"QR Code salvo em: {caminho}");
    }
}
