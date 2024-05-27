using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program r = new Program();
            r.elso();
            Console.WriteLine(" ");

            r.ketto();
            Console.WriteLine(" ");

            r.harmas();
            Console.WriteLine(" ");
            r.negyes();
            Console.WriteLine(" ");
            Console.ReadKey();
        }

        public string connstr = "server=localhost; user=root;database=dolgozok;port=3306;passworld=;";

        public void elso()
        {
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            string count ="select count(*) from dolgozok";
            MySqlCommand cmd = new MySqlCommand(count, conn);
            string counts = Convert.ToString(cmd.ExecuteScalar());
            Console.WriteLine("Number of records in 'dolgozok': " + counts);
            conn.Close();
        }

        public void ketto()
        {
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            string count = "SELECT dolgozok.nev FROM dolgozok WHERE dolgozok.ber=(SELECT MAX(dolgozok.ber) FROM dolgozok)";
            MySqlCommand cmd = new MySqlCommand(count, conn);
            string counts = Convert.ToString(cmd.ExecuteScalar());
            Console.WriteLine("Number of records in 'dolgozok': " + counts);
            conn.Close();
        }

        public void harmas()
        {
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            string countQuery = "SELECT COUNT(dolgozok.nev) FROM dolgozok GROUP BY dolgozok.reszleg;";
            MySqlCommand cmd = new MySqlCommand(countQuery, conn);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                List<string> counts = new List<string>();
                while (reader.Read())
                {
                    counts.Add(reader[0].ToString());
                }
                Console.WriteLine("Reszleg Counts:");
                foreach (string count in counts)
                {
                    Console.WriteLine(count);
                }
            }
            conn.Close();
        }


        public void negyes()
        {
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            string countQuery = "SELECT dolgozok.nev FROM dolgozok WHERE dolgozok.reszleg LIKE \"asztalosműhely\";\r\n";
            MySqlCommand cmd = new MySqlCommand(countQuery, conn);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                List<string> counts = new List<string>();
                while (reader.Read())
                {
                    counts.Add(reader[0].ToString());
                }
                Console.WriteLine("Asztalosmuhely nevek:");
                foreach (string count in counts)
                {
                    Console.WriteLine(count);
                }
            }
            conn.Close();
        }

    }
}
