using Show_N_Tell;

Fancy.PrintTitle();

Agenda agenda = new(new List<string>()
{
    "OpenCV for 2D convolution with image byte arrays",
    "Organic chemistry for development of biodegradable compliance packaging",
    "Manipulation of video/audio files",
});

agenda.Run();

while (true)
{
    Fancy.SayThanks();
    try
    {
        string? s = Reader.ReadLine(1000);
        if (s != null) break;
    }
    catch (TimeoutException) { }
}