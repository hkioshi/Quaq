using Quaq.Commands;
return await QuaqCli
    .Get()
    .Parse(args)
    .InvokeAsync();
