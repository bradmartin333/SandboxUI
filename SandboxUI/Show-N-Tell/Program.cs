using Show_N_Tell.Tools;

using Audio audio = new();
Task.Run(() => audio.BeginCalibration());
Console.ReadLine();
Task.Run(() => audio.EndCalibration());
Console.ReadLine();

Fancy.PrintTitle();
Console.ReadLine();

Agenda agenda = new(audio, new List<string>()
{
    "Maintaining hardware testers",
    "Documentation",
    "Aras for where-used hierarchy",
    "Keep computer from going idle",
    "Creating flowcharts",
});

Task.Run(() => Fancy.SayThanks(audio));
Console.ReadLine();