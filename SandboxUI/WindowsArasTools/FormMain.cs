using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsArasTools
{
    public partial class FormMain : Form
    {
        private static List<string> PartNumbers = new List<string>();
        private static List<int> PartNumbersIndex = new List<int>();
        private readonly static string DownloadPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "WindowsArasTools", "CADPDFs");

        public FormMain()
        {
            Directory.CreateDirectory(DownloadPath);
            InitializeComponent();
            CADPDFsWorker.ProgressChanged += CADPDFsWorker_ProgressChanged;
            CADPDFsWorker.RunWorkerCompleted += CADPDFsWorker_RunWorkerCompleted;
        }

        private void CADPDFsWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            for (int i = 0; i < PartNumbers.Count; i++)
            {
                System.Threading.Thread.Sleep(1000);
                if (CADPDFsWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                CADPDFsWorker.ReportProgress(PartNumbersIndex[i]);
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
            if (CADPDFsWorker.IsBusy)
            {
                CADPDFsWorker.CancelAsync();
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
                CADPDFsWorker.RunWorkerAsync();
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
    }
}
