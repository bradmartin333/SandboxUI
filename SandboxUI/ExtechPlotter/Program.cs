namespace ExtechPlotter
{
    public static class Program
    {
        const string ERR_MSG = "Invalid args: Follow .exe with path to folder containing Extech VBDXX folders.";

        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("ERR0 " + ERR_MSG);
                return;
            }

            int trim = 0;
            if (args.Length == 2) trim = int.Parse(args[1]);
            string testPath = args[0];
            string[] dirs = Directory.GetDirectories(testPath);
            if (dirs.Length == 0) dirs = new string[] { testPath };
            ApplicationConfiguration.Initialize();
            Application.Run(new Form(dirs, trim));
        }
    }
}