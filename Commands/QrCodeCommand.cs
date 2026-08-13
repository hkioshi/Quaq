using System.CommandLine;
using Quaq.Services.Media;
using Quaq.Interfaces;
namespace Quaq.Commands;

public class QrCodeCommand : IComando
{
    public Command Get()
    {
        var QrArg = new Argument<string>("url");
        var QrCmd = new Command("qrcode", "Gerador de qr code")
        {
            QrArg
        };
        QrCmd.SetAction(action => QrCodeService.GerarQrCode(action.GetValue(QrArg)!));

        return QrCmd;
    }
}
