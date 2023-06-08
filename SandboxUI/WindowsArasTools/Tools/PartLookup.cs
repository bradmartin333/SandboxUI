using Innovator.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsArasTools.Tools
{
    public partial class PartLookup : UserControl
    {
        private readonly static string DownloadPath = Path.Combine(FormMain.DownloadPath, "Part Lookup");
        private readonly List<string> Keywords = new List<string>();
        private List<string> Parts = new List<string>();
        private int NumResults = 0;

        public PartLookup()
        {
            InitializeComponent();
            CheckForCache();
        }

        private void NumPrefix_ValueChanged(object sender, EventArgs e)
        {
            CheckForCache();
        }

        private async void BtnDownloadCache_Click(object sender, EventArgs e)
        {
            if (!FormMain.ArasConnected) return;

            BtnDownloadCache.Text = "Downloading Cache...";
            BtnDownloadCache.Enabled = false;
            RtbKeywords.Enabled = false;
            RtbResults.Clear();
            Parts.Clear();

            string prefix = GetPartNumber();
            string path = Path.Combine(DownloadPath, $"{prefix}.txt");
            if (File.Exists(path))
                File.Delete(path);

            NumResults = 0;
            Task[] tasks = new Task[10];
            for (int i = 0; i < tasks.Length; i++)
            {
                int localTaskNum = i;
                tasks[i] = Task.Run(() => DownloadCache(prefix, localTaskNum));
            }
            await Task.WhenAll(tasks);

            Directory.CreateDirectory(DownloadPath);
            File.WriteAllLines(path, Parts);
            Parts.Clear();
            BtnDownloadCache.Enabled = true;

            CheckForCache();
        }

        private void DownloadCache(string prefix, int suffix)
        {
            int numFails = 0;
            int max = (suffix + 1) * 1000;
            for (int i = suffix * 1000; i < max; i++)
            {
                BtnDownloadCache.Invoke((MethodInvoker)delegate
                {
                    BtnDownloadCache.Text = $"Downloading Cache {NumResults / 9999.0:P}";
                });
                string padded = i.ToString();
                while (padded.Length < 4) padded = "0" + padded;
                var result = FormMain.Connection.Apply($@"<Item type='Part' action='get' select='item_number, name'>
                                                             <item_number>{prefix}-{padded}</item_number>
                                                          </Item>");
                NumResults++;
                if (result.Exception == null && result.ItemMax() != 0)
                {
                    string name = result.Items().First().Property("name").Value;
                    if (!string.IsNullOrEmpty(name))
                        Parts.AddRange(result.Items().Select(x => $"{x.Property("item_number").Value.Trim()}\t{x.Property("name").Value.Trim()}"));
                    numFails = 0;
                }
                else
                {
                    numFails++;
                    if (numFails > 100)
                    {
                        NumResults += max - i;
                        break;
                    }
                }
            };
        }

        private void CheckForCache()
        {
            string path = Path.Combine(DownloadPath, $"{GetPartNumber()}.txt");
            if (File.Exists(path))
            {
                LblFileCache.Text = $"File Cache Found";
                BtnDownloadCache.Text = "Re-Download Cache";
                RtbKeywords.Enabled = true;
                Parts = File.ReadAllLines(path).ToList();
            }
            else
            {
                LblFileCache.Text = $"No File Cache Found";
                BtnDownloadCache.Text = "Download Cache";
                RtbKeywords.Enabled = false;
            }
            RtbResults.Clear();
        }

        private string GetPartNumber()
        {
            return $"{NumPrefixA.Value}{NumPrefixB.Value}{NumPrefixC.Value}";
        }

        private void RtbKeywords_TextChanged(object sender, EventArgs e)
        {
            Keywords.Clear();

            foreach (string line in RtbKeywords.Lines)
            {
                if (string.IsNullOrEmpty(line)) continue;
                if (Keywords.Contains(line)) continue;
                if (line.Contains("Enter keywords")) continue;
                Keywords.Add(line);
            }

            GetResults();
        }

        private void GetResults()
        {
            List<string> matches = new List<string>();
            foreach (string part in Parts)
            {
                string name = part.ToLower();
                // See if the name contains all the keywords
                bool containsAll = true;
                foreach (string keyword in Keywords)
                    if (!name.Contains(keyword.ToLower()))
                    {
                        containsAll = false;
                        break;
                    }
                if (containsAll) matches.Add(part);
            }
            RtbResults.Text = string.Join(Environment.NewLine, matches);
        }
    }
}
