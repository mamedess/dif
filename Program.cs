using dif;
using Spectre.Console.Cli;

var app = new CommandApp<ContarLinhasCommand>();

app.Configure(config =>
{
    config.SetApplicationName("dif");
    config.AddExample(["./meu-projeto", "--ignore", "tests"]);
});

return app.Run(args);
