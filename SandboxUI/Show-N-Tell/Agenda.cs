namespace Show_N_Tell
{
    internal class Agenda
    {
        private readonly List<(int, string)> AgendaList = new();

        internal Agenda(List<string> prompts)
        {
            // Build list of tuples from user input
            foreach (string prompt in prompts)
                if (!string.IsNullOrEmpty(prompt))
                    AgendaList.Add(GetPromptVal(prompt));

            // Sort list by user input in descending order
            AgendaList.Sort((x, y) => y.Item1.CompareTo(x.Item1));
        }

        private static (int, string) GetPromptVal(string prompt)
        {
            int val;
            while (true)
            {
                Console.Write(prompt + ": ");
                if (int.TryParse(Console.ReadLine(), out val)) break;
                Console.WriteLine("That is not a valid number...");
            }
            return (val, prompt);
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
