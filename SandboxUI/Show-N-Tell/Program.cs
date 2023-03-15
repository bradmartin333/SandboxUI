using Show_N_Tell;

using Audio audio = new();

Fancy.PrintTitle();
Console.ReadLine();

Agenda agenda = new(audio, new List<string>()
{
    "OpenCV for 2D convolution with image byte arrays",
    "Organic chemistry for development of biodegradable compliance packaging",
    "Manipulation of video/audio files",
    "Creating and maintaining hardware testers",
    "Plotting data in Excel",
    "Create documentation",
    "Aras for where-used hierarchy",
    "SolidWorks for design of new 3D parts",
    "Keep computer from going idle for long processes",
    "Creating flowcharts",
    "Doing repetitive mouse/keyboard combinations",
});

Task.Run(() => Fancy.SayThanks(audio));
Console.ReadLine();