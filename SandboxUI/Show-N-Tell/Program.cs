using Show_N_Tell.Tools;

using Audio audio = new();
Task.Run(() => audio.BeginCalibration());
Console.ReadLine();
Task.Run(() => audio.EndCalibration());
Console.ReadLine();

Fancy.PrintTitle();
Console.ReadLine();

Agenda agenda = new(audio, new List<(string, string)>()
{
    ("Hardware testers", "Batter_01FEB2023.pptx, APMC video"),
    ("Documentation", "README.md, overleaf, typst"),
    ("Aras automation", "ArasAPI demo"),
    ("Flowcharts", "mermaid.js"),
    ("AI", "Bard, testai.py"),
});

Task.Run(() => Fancy.SayThanks(audio));
Console.ReadLine();