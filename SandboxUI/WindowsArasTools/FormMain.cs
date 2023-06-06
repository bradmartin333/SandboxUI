using Innovator.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WindowsArasTools
{
    public partial class FormMain : Form
    {
        private static readonly List<string> PartNumbers = new List<string>();
        private static readonly List<int> PartNumbersIndex = new List<int>();
        private readonly static string DownloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "WindowsArasTools", "CADPDFs");
        private static IRemoteConnection Connection;

        public FormMain()
        {
            Directory.CreateDirectory(DownloadPath);
            InitializeComponent();
            BgwCADPDFs.ProgressChanged += CADPDFsWorker_ProgressChanged;
            BgwCADPDFs.RunWorkerCompleted += CADPDFsWorker_RunWorkerCompleted;

            RtbCADPDFs.Text = "Connecting to Aras...\n";
            // Connect to Parata's Aras database with credentials
            try
            {
                Connection = Factory.GetConnection("http://ps-aras/InnovatorServer/Server/", "BMartin");
                string database = Connection.GetDatabases().First();
                Connection.Login(new ExplicitCredentials(database, "bmartin", "innovator"));
                RtbCADPDFs.Text += "Connected to Aras!\n";
                RtbCADPDFs.Text += "Replace this text with a list of Aras part numbers (One per line) that have an associated CAD PDF that you would like to download.\n";
                BtnCADPDFs.Enabled = true;
            }
            catch (Exception)
            {
                RtbCADPDFs.Text = "Failed to connect to Aras. Check your internet connection and try again.";
                BtnCADPDFs.Enabled = false;
            }
        }

        private void CADPDFsWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            for (int i = 0; i < PartNumbers.Count; i++)
            {
                if (BgwCADPDFs.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                if (DownloadPDF(PartNumbers[i]))
                    BgwCADPDFs.ReportProgress(PartNumbersIndex[i]);
            }
        }

        private void CADPDFsWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            ResetUI();
        }

        private void CADPDFsWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            ColorizeRTBLine(e.ProgressPercentage, Color.Green);
        }

        private void BtnCADPDFs_Click(object sender, EventArgs e)
        {
            if (BgwCADPDFs.IsBusy)
            {
                BgwCADPDFs.CancelAsync();
                ResetUI();
            }
            else
            {
                // Get all the part numbers from the RTB
                GetAllPartNumbers();
                // Change the button to a stop button
                BtnCADPDFs.Text = "Stop";
                BtnCADPDFs.BackColor = Color.LightCoral;
                // Disable the RTB
                RtbCADPDFs.Enabled = false;
                // Start the background worker
                BgwCADPDFs.RunWorkerAsync();
            }
        }

        private void ResetUI()
        {
            // Make the button a start button
            BtnCADPDFs.Text = "Start";
            BtnCADPDFs.BackColor = Color.LightGreen;
            // Enable the RTB
            RtbCADPDFs.Enabled = true;
        }

        private void GetAllPartNumbers()
        {
            PartNumbers.Clear();
            for (int i = 0; i < RtbCADPDFs.Lines.Length; i++)
            {
                string line = RtbCADPDFs.Lines[i];
                if (!string.IsNullOrEmpty(line))
                {
                    string cleanLine = line.Trim();
                    // Check if the line matches the format xxx-xxxx
                    if (cleanLine.Length != 8 || cleanLine[3] != '-')
                        ColorizeRTBLine(i, Color.Red);
                    else
                    {
                        if (PartNumbers.Contains(cleanLine))
                        {
                            line = "(Duplicate) " + line;
                            RtbCADPDFs.Lines[i] = line;
                            ColorizeRTBLine(i, Color.Gold);
                        }
                        else
                        {
                            PartNumbers.Add(cleanLine);
                            PartNumbersIndex.Add(i);
                            ColorizeRTBLine(i, Color.Black);
                        }
                    }
                }
            }
        }

        private void ColorizeRTBLine(int lineNumber, Color color)
        {
            RtbCADPDFs.Select(RtbCADPDFs.GetFirstCharIndexFromLine(lineNumber), RtbCADPDFs.Lines[lineNumber].Length);
            RtbCADPDFs.SelectionColor = color;
        }

        private bool DownloadPDF(string partNumber)
        {
            try
            {
                IReadOnlyResult cadItem = Connection.Apply(new Command($@"<Item type='CAD' action='get'>
                                                                        <item_number>{partNumber}.SLDDRW</item_number>
                                                                     </Item>"));
                IReadOnlyElement cadFile = cadItem.Items().First().Element("viewable_file");
                var stream = Connection.Process(new Command($"<Item type='File' action='get' id='{cadFile.Value}'/>").WithAction(CommandAction.DownloadFile));
                stream.Save(Path.Combine(DownloadPath, $"{partNumber}_slddrw.pdf"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
