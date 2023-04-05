namespace Show_N_Tell.Tools
{
    internal class Agenda
    {
        private readonly int LongestPrompt = 0;
        private readonly List<(float, (string, string))> AgendaList = new();

        internal Agenda(Audio audio, List<(string, string)> prompts)
        {
            foreach ((string, string) prompt in prompts)
                if (prompt.Item1.Length > LongestPrompt) LongestPrompt = prompt.Item1.Length;

            // Build list of tuples from user input audio
            foreach ((string, string) prompt in prompts)
                AgendaList.Add(GetPromptVal(prompt, audio));

            // Sort list by user input in descending order and run
            AgendaList.Sort((x, y) => y.Item1.CompareTo(x.Item1));
            Run();
        }

        private (float, (string, string)) GetPromptVal((string, string) prompt, Audio audio)
        {
            Console.Write(prompt.Item1);
            Thread.Sleep(3000);
            Console.Write(": ");

            // Add extra spaces so the audio bars start in the same place
            for (int i = 0; i < LongestPrompt - prompt.Item1.Length; i++)
                Console.Write(" ");
            
            int msDelay = 5;
            int samplingTimeSeconds = 5;
            int lastNumBars = 0;
            for (int i = 0; i < samplingTimeSeconds * 1000 / msDelay; i++)
            {
                int thisNumBars = audio.Bars;
                if (thisNumBars > lastNumBars)
                {
                    for (int j = 0; j < thisNumBars - lastNumBars; j++)
                        Console.Write("|");
                    lastNumBars = thisNumBars;
                    if (lastNumBars >= audio.MaxBars * 0.9f) // Peaking
                    {
                        Console.Write(">>>");
                        Thread.Sleep(1000); // Let people settle down
                        break;
                    }
                }
                Thread.Sleep(msDelay);
            }
            Console.WriteLine();

            return (lastNumBars, prompt);
        }

        private void Run()
        {
            for (int i = 0; i < AgendaList.Count; i++)
            {
                Fancy.PrintTitle();
                for (int j = 0; j < AgendaList.Count; j++)
                {
                    Console.ForegroundColor = i == j ? ConsoleColor.Green : ConsoleColor.White;
                    Console.Write(AgendaList[j].Item2.Item1);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(": " + AgendaList[j].Item2.Item2);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
}
