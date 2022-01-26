namespace ExtechPlotter
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form(string[] dirs, int trim)
        {
            InitializeComponent();

            List<(int, double)> plotData = new List<(int, double)>();
            DateTime start = DateTime.MinValue;
            string label = string.Empty;

            int idx = 0;
            try
            {
                foreach (string dir in dirs)
                {
                    string[] files = Directory.GetFiles(dir);
                    foreach (string file in files)
                    {
                        string[] data = File.ReadAllLines(file);
                        for (int i = 1; i < data.Length; i++)
                        {
                            string[] cols = data[i].Split('\t');
                            if (!cols[3].Contains("999"))
                            {
                                if (start == DateTime.MinValue)
                                {
                                    start = DateTime.Parse($"{cols[1]} {cols[2]}");
                                    label = cols[4];
                                }
                                plotData.Add((idx, double.Parse(cols[3])));
                            }
                            else
                                plotData.Add((idx, 0));
                            idx++;
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid file or directory structure. Exiting...");
                return;
            }

            int numPointsInADay = 24 * 60 * 60;
            var sig = formsPlot.Plot.AddSignal(
                plotData.Where(x => x.Item1 > trim && x.Item1 < (idx - trim)).Select(x => x.Item2).ToArray(), 
                numPointsInADay);
            sig.OffsetX = start.ToOADate();
            formsPlot.Plot.Title("Extech Data Log");
            formsPlot.Plot.SetCulture(System.Globalization.CultureInfo.CurrentCulture);
            formsPlot.Plot.XAxis.DateTimeFormat(true);
            formsPlot.Plot.XAxis.Label("Date and Time");
            formsPlot.Plot.YAxis.Label(label);
            formsPlot.Refresh();
        }
    }
}