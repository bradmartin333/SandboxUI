using ScottPlot;
using System.Drawing;

string[] files = new string[] { "empty.txt", "half.txt", "full.txt" };
string[] PWMs = Enumerable.Range(14, 10).Select(x => (x * 10).ToString()).ToArray();
double[] PWMplacement = Enumerable.Range(0, 10).Select(x => x * 80.0 + 80).Reverse().ToArray();

// Read files into memory
string[] raw = new string[3];
for (int i = 0; i < files.Length; i++)
    raw[i] = File.ReadAllText(files[i]);

// Init 3D array
double[][][] data = new double[3][][];
for (int i = 0; i < raw.Length; i++)
{
    data[i] = new double[10][];
    for (int j = 0; j < 10; j++)
        data[i][j] = new double[362];
}

for (int i = 0; i < raw.Length; i++)
{
    // Header is line 1: 230 220 210 200 190 180 170 160 150 140
    string[] lines = raw[i].Split('\n').Skip(1).ToArray();
    for (int j = 0; j < lines.Length; j++)
    {
        string[] cols = lines[j].Trim().Split("\t");
        for (int k = 0; k < cols.Length; k++)
            if (double.TryParse(cols[k], out double datum))
                data[i][k][j] = datum;
    }
}

var plt = new Plot(1070, 1000);
plt.Title("Parata Winder RPM with 3 load types at all PWM settings");
plt.XAxis.Label("Time (Minutes)");
plt.YAxis.Label("RPM");
plt.YAxis2.Layout(padding: 30);

for (int i = 0; i < raw.Length; i++)
{
    Color c = i switch
    {
        0 => Color.Red,
        1 => Color.Green,
        _ => Color.Blue,
    };
    string l = i switch
    {
        0 => "Empty",
        1 => "Half-Full",
        _ => "Full"
    };
    for (int j = 0; j < 10; j++)
    {
        ScottPlot.Plottable.SignalPlot sig = plt.AddSignal(data[i][j], 12, c, label:j == 0 ? l : null);
        ScottPlot.Plottable.Annotation pwm = plt.AddAnnotation(PWMs[j] + " PWM", 945, PWMplacement[j]);
        pwm.Font.Color = Color.Black;
        pwm.Shadow = false;
        pwm.BackgroundColor = Color.White;
        pwm.BorderColor = Color.White;
        if (j % 2 == 0)
            sig.LineWidth = 4;
        else
            pwm.Font.Bold = true;
    }
}

plt.AddAnnotation("Regular and bolded lines indicate PWM setting groups", 122, 8);
plt.AddAnnotation("Peaks are a deviation of 1-2 RPM", 34, 740);
plt.AddAnnotation("0 indicates the motor could not revolve,\nas excpected from a low speed setting", 682, 810);
plt.Legend(location:Alignment.UpperLeft);
plt.SaveFig("WinderPerformanceSummary.png");
