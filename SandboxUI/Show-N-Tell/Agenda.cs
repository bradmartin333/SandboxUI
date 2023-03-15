namespace Show_N_Tell
{
    internal class Agenda
    {
        private readonly int LongestPrompt = 0;
        private readonly List<(float, string)> AgendaList = new();

        internal Agenda(List<string> prompts)
        {
            using Audio audio = new();

            foreach (string prompt in prompts)
                if (prompt.Length > LongestPrompt) LongestPrompt = prompt.Length;

            // Build list of tuples from user input audio
            foreach (string prompt in prompts)
                AgendaList.Add(GetPromptVal(prompt, audio));

            // Sort list by user input in descending order
            AgendaList.Sort((x, y) => y.Item1.CompareTo(x.Item1));
        }

        private (float, string) GetPromptVal(string prompt, Audio audio)
        {
            Console.Write(prompt + ": ");

            // Add extra spaces so the audio bars start in the same place
            for (int i = 0; i < LongestPrompt - prompt.Length; i++)
                Console.Write(" ");

            Thread.Sleep(1000);
            int msDelay = 100;
            int samplingTimeSeconds = 5;
            int lastNumBars = 0;
            for (int i = 0; i < samplingTimeSeconds * 1000 / msDelay; i++)
            {
                int thisNumBars = audio.Bars;
                if (thisNumBars > lastNumBars)
                {
                    for (int j = 0; j < thisNumBars - lastNumBars; j++)
                        Console.Write("#");
                    lastNumBars = thisNumBars;
                    if (lastNumBars >= audio.MaxBars / 2) // Peaking
                    {
                        Console.Write("!!!");
                        Thread.Sleep(1000); // Let people settle down
                        break;
                    }
                }
                Thread.Sleep(msDelay);
            }
            Console.WriteLine();
            return (lastNumBars, prompt);
        }

        internal void Run()
        {
            for (int i = 0; i < AgendaList.Count; i++)
            {
                Fancy.PrintTitle();
                for (int j = 0; j < AgendaList.Count; j++)
                {
                    Console.ForegroundColor = i == j ? ConsoleColor.Green : ConsoleColor.White;
                    Console.WriteLine(AgendaList[j].Item2);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
            }
        }
    }
}
