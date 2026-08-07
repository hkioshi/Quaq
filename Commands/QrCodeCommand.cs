using Quaq.Commands.Interfaces;

using System.CommandLine;
using Quaq.Services.Media;
namespace Quaq.Commands;

public class QrCodeCommand : IComando
{
    public Command Get()
    {
        var QrCmd = new Command("qrcode", "Gerador de qr code");
        var QrArg = new Argument<string>("url");
        QrCmd.Add(QrArg);

        QrCmd.SetAction(action =>
        {
           QrCodeService.GerarQrCode(action.GetValue(QrArg)!); 
        });

        return QrCmd;
    }
}
