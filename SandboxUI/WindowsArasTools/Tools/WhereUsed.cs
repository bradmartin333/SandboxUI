using Innovator.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsArasTools.Tools
{
    public partial class WhereUsed : UserControl
    {
        public WhereUsed()
        {
            InitializeComponent();
        }

        private void TxtPartNumber_TextChanged(object sender, EventArgs e)
        {
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

        private void BtnRun_Click(object sender, EventArgs e)
        {
            BtnRun.BackColor = Color.Gold;
            RTB.Clear();
            string partNumber = TxtPartNumber.Text;
            RTB.Text = $"Searching for {partNumber}\n";
            RTB.Text += GetAllWhereUsedQuantity(partNumber);
            BtnRun.BackColor = Color.LimeGreen;
        }

        private static string GetAllWhereUsedQuantity(string queryPartNumber)
        {
            string output = "";
            string queryID = GetPartID(queryPartNumber);
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
                        if (!string.IsNullOrEmpty(partID))
                        {
                            string quantity = GetBOMQuantity(partID, queryPartNumber);
                            for (int i = 0; i < 75; i++)
                                output += '-';
                            output += $"\n{partNumber}";
                            if (!string.IsNullOrEmpty(quantity))
                                output += $"\t{quantity}";
                            output += "\n";
                        }
                    }
                }
            }
            return output;
        }

        public static string GetPartID(string partNumber)
        {
            IReadOnlyResult fetchID = FormMain.Connection.Apply($@"<Item type='Part' action='get' select='id'>
                                                                       <item_number>{partNumber}</item_number>
                                                                   </Item>");
            return fetchID.ItemMax() == 0 ? null : fetchID.Items().First().Attribute("id").Value;
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
    }
}
