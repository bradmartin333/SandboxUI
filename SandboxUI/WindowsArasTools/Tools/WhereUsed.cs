using Innovator.Client;
using System;
using System.Collections.Generic;
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

        private void button1_Click(object sender, EventArgs e)
        {
            string info = GetAllWhereUsedQuantity("305-0059");
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
                            if (!string.IsNullOrEmpty(quantity))
                                output += $"{partNumber}: {quantity}\n";
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
