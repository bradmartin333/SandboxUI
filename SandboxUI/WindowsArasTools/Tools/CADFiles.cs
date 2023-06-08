using Innovator.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsArasTools.Tools
{
    public partial class CADFiles : UserControl
    {
        private readonly static string DownloadPath = Path.Combine(FormMain.DownloadPath, "CAD Files");
        private readonly List<string> PartNumbers = new List<string>();
        private readonly List<int> PartNumbersIndex = new List<int>();
        private readonly BackgroundWorker BGW = new BackgroundWorker
        {
            WorkerReportsProgress = true,
            WorkerSupportsCancellation = true
        };

        public CADFiles()
        {
            InitializeComponent();

            // Connect to Parata's Aras database with credentials
            try
            {
                FormMain.Connection = Factory.GetConnection("http://ps-aras/InnovatorServer/Server/", "BMartin");
                string database = FormMain.Connection.GetDatabases().First();
                FormMain.Connection.Login(new ExplicitCredentials(database, "bmartin", "innovator"));
                RTB.Text += "Connected to Aras!\n\n";
                RTB.Text += "Replace this text with a list of Aras part numbers (One per line) that have an associated CAD PDF that you would like to download.\n";
                BGW.DoWork += BGW_DoWork;
                BGW.ProgressChanged += BGW_ProgressChanged;
                BGW.RunWorkerCompleted += BGW_RunWorkerCompleted;
            }
            catch (Exception)
            {
                RTB.Text += "Failed to connect to Aras. Check your internet connection and try again.";
            }
        }

        private void BGW_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < PartNumbers.Count; i++)
            {
                if (BGW.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                if (DownloadAllFiles(PartNumbers[i]))
                    BGW.ReportProgress(PartNumbersIndex[i]);
            }
        }

        private void BGW_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ColorizeRTBLine(e.ProgressPercentage, Color.Green);
        }

        private void BGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ResetUI();
        }

        private void ResetUI()
        {
                RTB.Enabled = true;
                BTN.Text = "Start";
                BTN.BackColor = Color.LightGreen;
        }

        private void GetAllPartNumbers()
        {
            PartNumbers.Clear();
            for (int i = 0; i < RTB.Lines.Length; i++)
            {
                string line = RTB.Lines[i];
                if (!string.IsNullOrEmpty(line))
                {
                    MatchCollection matches = Regex.Matches(line, @"(\d{3}-\d{4})");
                    if (matches.Count == 0)
                        ColorizeRTBLine(i, Color.Red);
                    else
                    {
                        string partNumber = matches[0].Value;
                        if (PartNumbers.Contains(partNumber))
                            ColorizeRTBLine(i, Color.Gold);
                        else
                        {
                            PartNumbers.Add(partNumber);
                            PartNumbersIndex.Add(i);
                            ColorizeRTBLine(i, Color.Black);
                        }
                    }
                }
            }
        }

        private void ColorizeRTBLine(int lineNumber, Color color)
        {
            RTB.Select(RTB.GetFirstCharIndexFromLine(lineNumber), RTB.Lines[lineNumber].Length);
            RTB.SelectionColor = color;
        }

        private bool DownloadAllFiles(string partNumber)
        {
            try
            {
                IReadOnlyResult cadItem = FormMain.Connection.Apply(new Command($@"<Item type='CAD' action='get'>
                                                                                       <item_number>{partNumber}.SLDDRW</item_number>
                                                                                   </Item>"));
                IReadOnlyResult cadItem2 = FormMain.Connection.Apply(new Command($@"<Item type='CAD' action='get'>
                                                                                       <item_number>{partNumber}.SLDPRT</item_number>
                                                                                   </Item>"));
                IReadOnlyResult cadItem3 = FormMain.Connection.Apply(new Command($@"<Item type='CAD' action='get'>
                                                                                       <item_number>{partNumber}.SLDASM</item_number>
                                                                                   </Item>"));
                var allItems = cadItem.Items().Concat(cadItem2.Items()).Concat(cadItem3.Items());

                bool success = false;
                string thisDir = Path.Combine(DownloadPath, partNumber);
                Directory.CreateDirectory(thisDir);

                foreach (var item in allItems)
                {
                    var nativeFile = item.Element("native_file");
                    if (nativeFile.Exists)
                        success = DownloadFile(Path.Combine(thisDir, nativeFile.Attribute("keyed_name").ToString()), nativeFile.Value);
                    var viewableFile = item.Element("viewable_file");
                    if (viewableFile.Exists)
                        success = DownloadFile(Path.Combine(thisDir, viewableFile.Attribute("keyed_name").ToString()), viewableFile.Value);
                }

                return success;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool DownloadFile(string path, string file)
        {
            try
            {
                var stream = FormMain.Connection.Process(new Command($"<Item type='File' action='get' id='{file}'/>").WithAction(CommandAction.DownloadFile));
                stream.Save(path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void BTN_Click(object sender, EventArgs e)
        {
            if (BGW.IsBusy)
            {
                BGW.CancelAsync();
                ResetUI();
            }
            else if (FormMain.ArasConnected)
            {
                // Get all the part numbers from the RTB
                GetAllPartNumbers();
                // Start the background worker
                BGW.RunWorkerAsync();
                // Change UI to show that the worker is running
                RTB.Enabled = false;
                BTN.Text = "Stop";
                BTN.BackColor = Color.LightCoral;
            }
        }
    }
}
