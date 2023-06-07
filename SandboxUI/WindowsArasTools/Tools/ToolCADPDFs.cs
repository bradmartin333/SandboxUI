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
    public class ToolCADPDFs
    {
        private readonly static string DownloadPath = Path.Combine(FormMain.DownloadPath, "CADPDFs");
        private readonly List<string> PartNumbers = new List<string>();
        private readonly List<int> PartNumbersIndex = new List<int>();
        private readonly RichTextBox RTB;
        private readonly BackgroundWorker BGW = new BackgroundWorker
        {
            WorkerReportsProgress = true,
            WorkerSupportsCancellation = true
        };
        private readonly Button BTN;

        public ToolCADPDFs(RichTextBox rtb, Button btn)
        {
            RTB = rtb;
            BTN = btn;
            BTN.Click += BTN_Click;
            BGW.DoWork += BGW_DoWork;
            BGW.ProgressChanged += BGW_ProgressChanged;
            BGW.RunWorkerCompleted += BGW_RunWorkerCompleted;
        }

        private void BTN_Click(object sender, EventArgs e)
        {
            if (BGW.IsBusy)
            {
                BGW.CancelAsync();
                ResetUI();
            }
            else
            {
                // Get all the part numbers from the RTB
                GetAllPartNumbers();
                // Start the background worker
                BGW.RunWorkerAsync();
                // Change UI to show that the worker is running
                RTB.BeginInvoke(new MethodInvoker(delegate
                {
                    RTB.Enabled = false;
                }));
                BTN.BeginInvoke(new MethodInvoker(delegate
                {
                    BTN.Text = "Stop";
                    BTN.BackColor = Color.LightCoral;
                }));
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
                if (DownloadPDF(PartNumbers[i]))
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
            RTB.BeginInvoke(new MethodInvoker(delegate
            {
                RTB.Enabled = true;
            }));
            BTN.BeginInvoke(new MethodInvoker(delegate
            {
                BTN.Text = "Start";
                BTN.BackColor = Color.LightGreen;
            }));
        }

        private void GetAllPartNumbers()
        {
            PartNumbers.Clear();
            for (int i = 0; i < RTB.Lines.Length; i++)
            {
                string line = RTB.Lines[i];
                if (!string.IsNullOrEmpty(line))
                {
                    string cleanLine = line.Trim();
                    MatchCollection matches = Regex.Matches(cleanLine, @"(\d{3}-\d{4})");
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
                            RTB.Text = RTB.Text.Replace(cleanLine, partNumber);
                        }
                    }
                }
            }
        }

        private void ColorizeRTBLine(int lineNumber, Color color)
        {
            RTB.BeginInvoke(new MethodInvoker(delegate
            {
                RTB.Select(RTB.GetFirstCharIndexFromLine(lineNumber), RTB.Lines[lineNumber].Length);
                RTB.SelectionColor = color;
            }));
        }

        private bool DownloadPDF(string partNumber)
        {
            try
            {
                IReadOnlyResult cadItem = FormMain.Connection.Apply(new Command($@"<Item type='CAD' action='get'>
                                                                                       <item_number>{partNumber}.SLDDRW</item_number>
                                                                                   </Item>"));
                IReadOnlyElement cadFile = cadItem.Items().First().Element("viewable_file");
                var stream = FormMain.Connection.Process(new Command($"<Item type='File' action='get' id='{cadFile.Value}'/>").WithAction(CommandAction.DownloadFile));
                Directory.CreateDirectory(DownloadPath);
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
