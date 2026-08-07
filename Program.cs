using Quaq.Commands;

var root = new QuaqCli().Get();

root.Add(new VelhaCommand().Get());
root.Add(new PomodoroCommand().Get());
root.Add(new ContatoCommand().Get());
root.Add(new EmailCommand().Get());
root.Add(new FalaCommand().Get());
root.Add(new NavegacaoCommand().Get());
root.Add(new DadosCommand().Get());
root.Add(new MP3Command().Get());
root.Add(new ProjetosCommand().Get());
root.Add(new IaCommand().Get());
root.Add(new CaluladoraCommand().Get());
root.Add(new QrCodeCommand().Get());
root.Add(new CameraCommand().Get());
root.Add(new RunCommand().Get());
root.Add(new GodotCommand().Get());
root.Add(new IpCommand().Get());
root.Add(new AdviceCommand().Get());
root.Add(new PlaylistCommand().Get());
root.Add(new NovoCommand().Get());
root.Add(new AnotacoesCommand().Get());
root.Add(new JogosCommand().Get());
//root.Add(new NotasCommand().Get());


    // new UpdateCommand().Get();


return await root.Parse(args).InvokeAsync();
