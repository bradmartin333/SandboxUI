using Innovator.Client;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArasAPI
{
    internal class Program
    {
        private static IRemoteConnection Connection;

        static void Main(string[] args)
        {
            // Welcome
            Console.WriteLine("This is a program to test the Aras API");
            Console.WriteLine("Here a where-used tree is generated from a part ID\n");

            // Connect to Parata's Aras database with credentials
            Connection = Factory.GetConnection("http://ps-aras/InnovatorServer/Server/", "BMartin");
            string database = Connection.GetDatabases().First();
            Connection.Login(new ExplicitCredentials(database, "bmartin", "innovator"));

            // Prompt user for initial ID
            // string initialID = "2BE9E92A012F4803AD1933D1D8C101B6";
            Console.WriteLine("Enter part ID");
            string initialID = Console.ReadLine();
            Console.Write("Working...");

            // Recursively find parents and add them to the list as new parts
            List<FoundPart> foundParts = new List<FoundPart>() { PartFromID(initialID) };
            while(true)
            {
                List<FoundPart> iterParts = foundParts.Where(x => !x.Complete).ToList();
                if (iterParts.Count == 0) break; // Every part and its parent has been checked
                foreach(FoundPart part in iterParts)
                {
                    IReadOnlyElement[] whereUsed = Connection.Apply($@"<Item type='Part' id='{part.ID}' action='getItemWhereUsed'/>")
                                                       .Items().First().Elements().ToArray();
                    if (whereUsed.Any())
                    {
                        IReadOnlyElement[] parents = whereUsed.First().Elements()
                                                              .Where(x => x.Attribute("type").Value == "Part").ToArray();
                        foreach (var parent in parents)
                        {
                            FoundPart newPart = PartFromID(parent.ToXml().Attribute("id").Value);
                            newPart.Child = part;
                            foundParts.Add(newPart);
                            Console.Write(".");
                        }
                    }
                    part.Complete = true;
                }
            }

            // Assign a graph node letter to each part
            int idx = 0;
            var groups = foundParts.GroupBy(x => x.ItemNumber);
            foreach (var group in groups)
            {
                foreach (var item in group)
                    item.GroupID = ((char)(idx + 65)).ToString();
                idx++;
            }

            // Remove replicates but preserve relationships and make graph string
            List<string> relationships = foundParts.Select(x => x.ToString()).Distinct().ToList();
            string graph = string.Join("\n", relationships);

            // Create .html and open it in browser
            Console.WriteLine();
            Console.WriteLine("Making graph...");
            string html = System.IO.File.ReadAllText("mermaid.html");
            System.IO.File.WriteAllText("index.html", html.Replace("###GRAPH###", graph));
            Console.WriteLine("Opening graph...");
            System.Diagnostics.Process.Start("index.html");
        }

        internal static FoundPart PartFromID(string id)
        {
            IReadOnlyItem initialPartInfo = Connection.Apply($@"<Item type='Part' action='get' id='{id}'/>").Items().First();
            return new FoundPart(initialPartInfo);
        }
    }

    internal class FoundPart
    {
        public string ID { get; set; }
        public string ItemNumber { get; set; }
        public string Name { get; set; }
        public FoundPart Child { get; set; } = null;
        public bool Complete = false;
        public string GroupID { get; set; }

        public FoundPart(IReadOnlyElement partInfo) 
        { 
            ID = partInfo.Element("id").Value;
            ItemNumber = partInfo.Element("item_number").Value;
            Name = partInfo.Element("name").Value;
        }

        public override string ToString()
        {
            return $"{GroupID}[{ItemNumber} {Name}]{(Child == null ? "" : $" --> {Child.GroupID}[{Child.ItemNumber} {Child.Name}];")}";
        }
    }
}
