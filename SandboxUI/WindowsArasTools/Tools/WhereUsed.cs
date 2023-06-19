using Innovator.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsArasTools.Tools
{
    public partial class WhereUsed : UserControl
    {
        private readonly static string DownloadPath = Path.Combine(FormMain.DownloadPath, "WhereUsed");
        private static string QueryPartNumber = null;

        public WhereUsed()
        {
            InitializeComponent();
        }

        private void TxtPartNumber_TextChanged(object sender, EventArgs e)
        {
            QueryPartNumber = null;
            WebBrowser.DocumentText = "";
            if (System.Text.RegularExpressions.Regex.IsMatch(TxtPartNumber.Text, @"^(\d{3}-\d{4})$"))
            {
                TxtPartNumber.BackColor = Color.White;
                BtnRun.BackColor = Color.LimeGreen;
                BtnRun.Enabled = true;
            }
            else
            {
                TxtPartNumber.BackColor = Color.Firebrick;
                BtnRun.BackColor = Color.White;
                BtnRun.Enabled = false;
            }
        }

        private async void BtnRun_Click(object sender, EventArgs e)
        {
            QueryPartNumber = TxtPartNumber.Text;
            BtnRun.BackColor = Color.Gold;
            Application.DoEvents();
            WebBrowser.DocumentText = "";
            string result = await Task.Run(() => GetAllWhereUsedQuantity());
            WebBrowser.DocumentText = result;
            BtnRun.BackColor = Color.LimeGreen;
        }

        private static string GetAllWhereUsedQuantity()
        {
            string output = $"<html><body>Looking for: {QueryPartNumber}<br><br>";
            output += "<table border='1' style='text-align: center;'><tr><th>Part Number</th><th>Name</th><th>Quantity</th></tr>";
            string queryID = GetPartID(QueryPartNumber);
            if (!string.IsNullOrEmpty(queryID))
            {
                IReadOnlyElement[] fetchWhereUsed = FormMain.Connection.Apply($@"<Item type='Part' id='{queryID}' action='getItemWhereUsed'/>")
                                                       .Items().First().Elements().ToArray();
                if (fetchWhereUsed.Any())
                {
                    IReadOnlyElement[] whereUsedList = fetchWhereUsed.First().Elements().Where(x => x.Attribute("type").Value == "Part").ToArray();
                    string[] whereUsedParts = whereUsedList.Select(x => 
                        System.Text.RegularExpressions.Regex.Match(x.Attribute("keyed_name").Value, @".*(\d{3}-\d{4}.*) - .*").Groups[1].Value)
                        .Distinct().ToArray();
                    foreach (string partNumber in whereUsedParts)
                    {
                        string partID = GetPartID(partNumber);
                        string name = GetPartName(partNumber);
                        string quantity = GetBOMQuantity(partID, QueryPartNumber);
                        output += $"<tr><td>{partNumber}</td><td>{name}</td><td>{quantity}</td></tr>";
                    }
                }
            }
            output += "</table></body></html>";
            return output;
        }

        public static string GetPartID(string partNumber)
        {
            IReadOnlyResult fetchID = FormMain.Connection.Apply($@"<Item type='Part' action='get' select='id'>
                                                                       <item_number>{partNumber}</item_number>
                                                                   </Item>");
            return fetchID.ItemMax() == 0 ? null : fetchID.Items().First().Attribute("id").Value;
        }

        public static string GetPartName(string partNumber)
        {
            IReadOnlyResult fetchName = FormMain.Connection.Apply($@"<Item type='Part' action='get' select='name'>
                                                                       <item_number>{partNumber}</item_number>
                                                                   </Item>");
            return fetchName.ItemMax() == 0 ? null : fetchName.Items().First().Element("name").Value;
        }

        public static string GetBOMQuantity(string parentID, string queryPartNumber)
        {
            IReadOnlyResult results = FormMain.Connection.Apply(@"<Item type='Part' action='get' select='item_number,description,cost' id='@0'>
                                                                      <Relationships>
                                                                          <Item type='Part BOM' action='get' select='quantity,related_id(item_number,description,cost)' />
                                                                      </Relationships>
                                                                  </Item>", parentID);
            IEnumerable<IReadOnlyItem> bomItems = results.AssertItem().Relationships();
            foreach (IReadOnlyItem bom in bomItems)
            {
                IReadOnlyItem bomPart = bom.RelatedItem();
                if (bomPart != null && bomPart.Property("item_number").Value == queryPartNumber)
                    return bom.Property("quantity").Value;
            }
            return null;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(QueryPartNumber))
            {
                Directory.CreateDirectory(DownloadPath);
                string fileName = Path.Combine(DownloadPath, $"{QueryPartNumber}.html");
                File.WriteAllText(fileName, WebBrowser.DocumentText);
                MessageBox.Show($"File saved to: {fileName}");
            }
        }
    }
}
