using Innovator.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsArasTools.Tools
{
    public partial class FileLookup : UserControl
    {
        private readonly static string DownloadPath = Path.Combine(FormMain.DownloadPath, "FileLookup.txt");
        private readonly List<string> Keywords = new List<string>();
        private List<string> Parts = new List<string>();
        private static string AllFilesString = string.Empty;

        public FileLookup()
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

            BtnDownloadCache.Text = "Downloading File Cache...";
            BtnDownloadCache.Enabled = false;
            RtbKeywords.Enabled = false;
            RtbResults.Clear();
            Parts.Clear();

            if (File.Exists(DownloadPath))
                File.Delete(DownloadPath);

            await Task.Run(() => DownloadCache());

            File.WriteAllLines(DownloadPath, Parts);
            Parts.Clear();
            BtnDownloadCache.Enabled = true;

            CheckForCache();
        }

        private void DownloadCache()
        {
            var result = FormMain.Connection.Apply($@"<Item type='Document' action='get' select='item_number, name'><state condition='ne'>Deprecated</state></Item>");
            var items = result.Items();
            foreach (var item in items)
                try
                {
                    string name = item.Element("name").Value.Trim();
                    if (!name.ToLower().Contains("deprecated"))
                        Parts.Add($"{item.Element("item_number").Value.Trim()}\t{item.Element("name").Value.Trim()}");
                }
                catch (Exception) { }
            AllFilesString = string.Join(Environment.NewLine, Parts);
        }

        private void CheckForCache()
        {
            if (File.Exists(DownloadPath))
            {
                LblFileCache.Text = $"File Cache Found";
                BtnDownloadCache.Text = "Re-Download File Cache";
                RtbKeywords.Enabled = true;
                Parts = File.ReadAllLines(DownloadPath).ToList();
                AllFilesString= string.Join(Environment.NewLine, Parts);
            }
            else
            {
                LblFileCache.Text = $"No File Cache Found";
                BtnDownloadCache.Text = "Download File Cache";
                RtbKeywords.Enabled = false;
            }
            RtbResults.Clear();
        }


        private void RtbKeywords_TextChanged(object sender, EventArgs e)
        {
            Keywords.Clear();

            foreach (string line in RtbKeywords.Lines)
            {
                if (string.IsNullOrEmpty(line.Trim())) continue;
                if (Keywords.Contains(line)) continue;
                if (line.Contains("Enter keywords")) continue;
                Keywords.Add(line);
            }

            if (Keywords.Any())
                GetResults();
            else
                RtbResults.Text = AllFilesString;
        }

        private void GetResults()
        {
            var keywords = new HashSet<string>(Keywords.Select(line => line.ToLower().Trim()));
            StringBuilder sb = new StringBuilder();
            Parallel.ForEach(Parts, part =>
            {
                try
                {
                    var name = part.ToLower();
                    if (keywords.All(keyword => name.Contains(keyword)))
                        if (sb.Length < sb.Capacity)
                            sb.AppendLine(part);
                }
                catch (Exception) { }
            });
            if (sb.Length < RtbResults.MaxLength)
                RtbResults.Text = sb.ToString();
            else
                RtbResults.Text = AllFilesString;
        }
    }
}
