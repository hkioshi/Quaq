using System.CommandLine;
using Quaq.Interfaces;
using Quaq.Services.Media;

namespace Quaq.Commands;

public class CameraCommand : IComando
{
    public Command Get()
    {
        var cameraCmd = new Command("camera", "Abre a câmera");

        cameraCmd.SetAction(_ => CameraService.AbrirCamera());

        return cameraCmd;
    }
}
