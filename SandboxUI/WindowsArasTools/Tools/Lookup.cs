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
    public partial class Lookup : UserControl
    {
        public enum LookupTypes
        {
            Part,
            Document
        }

        private string DownloadPath;
        private string SearchString;
        private readonly List<string> Keywords = new List<string>();
        private List<string> Results = new List<string>();
        private string FullString = string.Empty;

        public Lookup()
        {
            InitializeComponent();
        }

        public void Initialize(LookupTypes lookupType)
        {
            SearchString = lookupType == LookupTypes.Document ? "Document" : "Part";
            DownloadPath = Path.Combine(FormMain.DownloadPath, $"{SearchString}Lookup.txt");
            CheckForCache();
        }

        private void NumPrefix_ValueChanged(object sender, EventArgs e)
        {
            CheckForCache();
        }

        private async void BtnDownloadCache_Click(object sender, EventArgs e)
        {
            if (!FormMain.ArasConnected) return;

            BtnDownloadCache.Text = $"Downloading {SearchString} Cache...";
            BtnDownloadCache.Enabled = false;
            RtbKeywords.Enabled = false;
            WebResults.DocumentText = string.Empty;
            Results.Clear();

            if (File.Exists(DownloadPath))
                File.Delete(DownloadPath);

            await Task.Run(() => DownloadCache());

            File.WriteAllLines(DownloadPath, Results);
            Results.Clear();
            BtnDownloadCache.Enabled = true;

            CheckForCache();
        }

        private void DownloadCache()
        {
            var result = FormMain.Connection.Apply($@"<Item type='{SearchString}' action='get' select='item_number, name'><state condition='ne'>Deprecated</state></Item>");
            var items = result.Items();
            foreach (var item in items)
                try
                {
                    string name = item.Element("name").Value.Trim();
                    if (!name.ToLower().Contains("deprecate"))
                        Results.Add($"{item.Element("item_number").Value.Trim()}&emsp;{item.Element("name").Value.Trim()}");
                }
                catch (Exception) { }
        }

        private void CheckForCache()
        {
            if (File.Exists(DownloadPath))
            {
                LblCache.Text = $"{SearchString} Cache Found";
                BtnDownloadCache.Text = $"Re-Download {SearchString} Cache";
                RtbKeywords.Enabled = true;
                Results = File.ReadAllLines(DownloadPath).ToList();
                FullString= string.Join("</br>", Results);
            }
            else
            {
                LblCache.Text = $"No {SearchString} Cache Found";
                BtnDownloadCache.Text = $"Download {SearchString} Cache";
                RtbKeywords.Enabled = false;
            }
            WebResults.DocumentText = string.Empty;
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
                WebResults.DocumentText = FullString;
        }

        private void GetResults()
        {
            var keywords = new HashSet<string>(Keywords.Select(line => line.ToLower().Trim()));
            StringBuilder sb = new StringBuilder();
            foreach (var result in Results)
            {
                try
                {
                    var name = result.ToLower();
                    if (keywords.All(keyword => name.Contains(keyword)))
                        if (sb.Length < sb.MaxCapacity)
                            sb.AppendLine(result + "</br>");
                }
                catch (Exception) { }
            }
            WebResults.DocumentText = sb.ToString();
        }
    }
}
