using Show_N_Tell;

using Audio audio = new();

Fancy.PrintTitle();
Console.ReadLine();

Agenda agenda = new(audio, new List<string>()
{
    "OpenCV for 2D convolution with image byte arrays",
    "Organic chemistry for development of biodegradable compliance packaging",
    "Manipulation of video/audio files",
});

Task.Run(() => Fancy.SayThanks(audio));
Console.ReadLine();