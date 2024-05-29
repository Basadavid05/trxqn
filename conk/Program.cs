using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ConsoleApp3
{
    internal class Program
    {
        static List<finale> finales = new List<finale>();
        class finale
        {
            public string nev;
            public int kaloria;
            public double mer1;
            public double mer2;
            public double mer3;
            public double mer4;
            public double mer5;
        }

        public static string linker = "server=localhost;username=root;database=levesek;port=3306;passworld=;";

        static void Main(string[] args)
        {
            elso();
            feladat();
            feladat1();
            Console.ReadKey();

        }
        private static void elso()
        {
            finales.Clear();
            MySqlConnection conn = new MySqlConnection(linker);
            conn.Open();
            string select = "Select * from levesek";
            MySqlCommand cmd = new MySqlCommand(select, conn);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    finale nes = new finale();
                    nes.nev = reader.GetString("megnevezes");
                    nes.kaloria = reader.GetInt32("kaloria");
                    nes.mer1 = reader.GetDouble("feherje");
                    nes.mer2 = reader.GetDouble("zsir");
                    nes.mer3 = reader.GetDouble("szenhidrat");
                    nes.mer4 = reader.GetDouble("hamu");
                    nes.mer5 = reader.GetDouble("rost");
                    finales.Add(nes);
                }
            }
            conn.Close();

            Console.WriteLine(finales.Count);
            Console.WriteLine(" ");

        }

        private static void feladat1()
        {
            Console.WriteLine(" ");
            foreach (var item in finales.FindAll(a=>a.nev.Equals("jozsisuti")))
            {
                Console.WriteLine(item.nev+" "+item.kaloria);
            }
        }

        //Egyre jó
        private static void feladat()
        {
            finale legkorabb = finales.Find(a=>a.kaloria== finales.Max(b=>b.kaloria));
            Console.WriteLine($"{legkorabb.nev} {legkorabb.kaloria}");
        }
    }
}
