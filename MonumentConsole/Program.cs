using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace MonumentConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new MonumentContext())
            {
                Console.WriteLine("Opret monument: ");
                var name = Console.ReadLine();

                var monument = new MonumentOversigt();
                db.MonumentOversigts.Add(monument);
                db.SaveChanges();

                var query = from m in db.MonumentOversigts
                    orderby m.Navn
                    select m;

                Console.WriteLine("Alle monumenter: ");

                foreach (var oversigt in query)
                {
                    Console.WriteLine(oversigt.Navn);
                }
            }
        }
    }
}
