using Innovator.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ArasAPI
{
    internal class Program
    {
        private static IRemoteConnection Connection;

        static void Main(string[] args)
        {
            // Connect to Parata's Aras database with credentials
            Connection = Factory.GetConnection("http://ps-aras/InnovatorServer/Server/", "BMartin");
            string database = Connection.GetDatabases().First();
            Connection.Login(new ExplicitCredentials(database, "bmartin", "innovator"));

            // Welcome user and state that parts are loading
            Console.WriteLine("Welcome to the Aras API test program");
            string[] pcbParts = GetAllPCBParts();

            while (true)
            {
                // Ask user for keywords and make a list of them
                Console.WriteLine("Enter keywords to search for. Press enter to finish.");
                Console.WriteLine("Use the shortest possible keywords to get the best results");
                List<string> keywords = new List<string>();
                while (true)
                {
                    Console.Write("Keyword: ");
                    string keyword = Console.ReadLine();
                    if (string.IsNullOrEmpty(keyword)) break;
                    keywords.Add(keyword);
                }

                // Search for parts with the keywords
                List<string> matches = new List<string>();
                foreach (string partName in pcbParts)
                {
                    string name = partName.ToLower();
                    // See if the name contains all the keywords
                    bool containsAll = true;
                    foreach (string keyword in keywords)
                        if (!name.Contains(keyword.ToLower()))
                        {
                            containsAll = false;
                            break;
                        }
                    if (containsAll) matches.Add(partName);
                }

                // Print out the results
                Console.WriteLine();
                Console.WriteLine("Found parts:");
                foreach (string match in matches)
                    Console.WriteLine(match);

                // Ask user if they want to search again
                Console.WriteLine();
                Console.WriteLine("Search again? (y/n)");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.KeyChar != 'y') break;
                Console.WriteLine("\n");
            }
        }

        private static string[] GetAllPCBParts()
        {
            // Get a .txt file in the temp directory
            string tempPath = Path.Combine(Path.GetTempPath() + "305parts.txt");

            // If the file exists, ask the user if they want to use it
            if (File.Exists(tempPath))
            {
                Console.WriteLine("Found a file with 305 parts. Use it? (y/n)");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.KeyChar == 'y')
                {
                    Console.WriteLine();
                    return File.ReadAllLines(tempPath);
                }
            }

            Console.WriteLine("Loading 305* parts up to 305-2*: ");
            int numPartsToSearch = 2000;
            List<string> partNames = new List<string>();
            for (int i = 0; i < numPartsToSearch; i++)
            {
                string padded = i.ToString();
                while (padded.Length < 4) padded = "0" + padded;
                var result = Connection.Apply($@"<Item type='Part' action='get' select='item_number, name'>
                                                  <item_number>305-{padded}</item_number>
                                               </Item>");
                if (result.ItemMax() == 0) continue;
                string name = result.Items().First().Property("name").Value;
                if (string.IsNullOrEmpty(name)) continue;
                partNames.AddRange(result.Items().Select(x => $"{x.Property("item_number").Value}\t{x.Property("name").Value}"));
                Console.SetCursorPosition(33, 1);
                Console.Write(i.ToString());
            }
            Console.WriteLine("\n");

            // Overwrite the file with the new parts
            File.WriteAllLines(tempPath, partNames);

            return partNames.ToArray();
        }

        private static void MakeWhereUsedChart()
        {
            // Prompt user for initial ID
            // string initialID = "2BE9E92A012F4803AD1933D1D8C101B6";
            Console.WriteLine("Enter part ID");
            string initialID = Console.ReadLine();
            Console.Write("Working...");

            // Recursively find parents and add them to the list as new parts
            List<FoundPart> foundParts = new List<FoundPart>() { PartFromID(initialID) };
            while (true)
            {
                List<FoundPart> iterParts = foundParts.Where(x => !x.Complete).ToList();
                if (iterParts.Count == 0) break; // Every part and its parent has been checked
                foreach (FoundPart part in iterParts)
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
                            string name = newPart.Name.ToLower();
                            if (name.Contains("deprecated") || name.Contains("replaced")) break;
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
                    item.GroupID = ((char)Clamp(idx + 65, 65, 90)).ToString() + idx.ToString();
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

        private static FoundPart PartFromID(string id)
        {
            IReadOnlyItem initialPartInfo = Connection.Apply($@"<Item type='Part' action='get' id='{id}'/>").Items().First();
            return new FoundPart(initialPartInfo);
        }

        private static int Clamp(int val, int min, int max)
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
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
            Name = partInfo.Element("name").Value.Replace("\"", "in.");
        }

        public override string ToString()
        {
            return $"{GroupID}[\"{ItemNumber} {Name}\"]{(Child == null ? "" : $" --> {Child.GroupID}[\"{Child.ItemNumber} {Child.Name}\"]")};";
        }
    }
}
