using Innovator.Client;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArasAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRemoteConnection conn = Factory.GetConnection("http://ps-aras/InnovatorServer/Server/", "BMartin");
            string database = conn.GetDatabases().First();
            conn.Login(new ExplicitCredentials(database, "bmartin", "innovator"));

            string initialID = "2BE9E92A012F4803AD1933D1D8C101B6";
            List<FoundPart> foundParts = new List<FoundPart>() { PartFromID(initialID, conn) };

            while(true)
            {
                List<FoundPart> iterParts = foundParts.Where(x => !x.Complete).ToList();
                if (iterParts.Count == 0) break;
                List<FoundPart> newParts = new List<FoundPart>();
                foreach(FoundPart part in iterParts)
                {
                    IReadOnlyElement[] whereUsedArr = conn.Apply($@"<Item type='Part' id='{part.ID}' action='getItemWhereUsed'/>").Items().First().Elements().ToArray();
                    if (whereUsedArr.Any())
                    {
                        IReadOnlyElement[] parents = whereUsedArr.First().Elements().Where(x => x.Attribute("type").Value == "Part").ToArray();
                        foreach (var parent in parents)
                        {
                            FoundPart newPart = PartFromID(parent.ToXml().Attribute("id").Value, conn);
                            newPart.Child = part;
                            newParts.Add(newPart);
                        }
                    }
                    part.Complete = true;
                }
                foundParts.AddRange(newParts);
            }

            var groups = foundParts.GroupBy(x => x.ItemNumber);
            foreach (var group in groups)
                Console.WriteLine(group.First());

            Console.ReadKey();
        }

        internal static FoundPart PartFromID(string id, IRemoteConnection conn)
        {
            IReadOnlyItem initialPartInfo = conn.Apply($@"<Item type='Part' action='get' id='{id}'/>").Items().First();
            return new FoundPart(initialPartInfo);
        }
    }

    internal class FoundPart
    {
        public string ID { get; set; }
        public string ItemNumber { get; set; }
        public string MajorRev { get; set; }
        public string Generation { get; set; }
        public FoundPart Child { get; set; } = null;
        public bool Complete = false;

        public FoundPart(IReadOnlyElement partInfo) 
        { 
            ID = partInfo.Element("id").Value;
            ItemNumber = partInfo.Element("item_number").Value;
            MajorRev = partInfo.Element("major_rev").Value;
            Generation = partInfo.Element("generation").Value;
        }

        public override string ToString() => $"{ItemNumber} -> {(Child == null ? "none" : Child.ItemNumber)}";
    }
}
