using MySql.Data.MySqlClient;
using System.Globalization;
using System.Security.Policy;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FinalTry
{
    

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string sqllink = "server=localhost;user=root;database=tagdij; port=3306;passworld=;";

         class Final
        {
            public int azon { get;  set; }
            public string nev { get;  set; }
            public string szuldatum { get;  set; }
            public int irszam { get;  set; }

            public string orsz { get;  set; }
        }

        Final selectedFinal;



        public MainWindow()
        {
            InitializeComponent();
            databaseGrid.SelectionChanged += databaseGrid_selectionChanged;

            Beolvas();

        }

        public void Beolvas()
        {
            databaseGrid.Items.Clear();
            List<Final> finale = new List<Final>();
            MySqlConnection ss = new MySqlConnection(sqllink);
            string a = "Select * From ugyfel";
            ss.Open();
            MySqlCommand command = new MySqlCommand(a, ss);
            using (MySqlDataReader dr = command.ExecuteReader())
            {
                while (dr.Read())
                {
                    Final final = new Final();
                    final.azon = dr.GetInt32(0);
                    final.nev = dr.GetString(1);
                    // Parse the date with a specific format
                    final.szuldatum = dr.GetDateTime(2).ToString("yyyy-MM-dd");
                    final.irszam = dr.GetInt32(3);
                    final.orsz = dr.GetString(4);
                    finale.Add(final);
                    databaseGrid.Items.Add(final);
                }
            }
            ss.Close();
        }

        private void databaseGrid_selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (databaseGrid.SelectedItem != null)
            {
                // Retrieve the selected item from the DataGrid
                selectedFinal = (Final)databaseGrid.SelectedItem;
                
                e1.IsEnabled = true;
                e2.IsEnabled = true;
                e3.IsEnabled = true;
                e4.IsEnabled = true;
                e5.IsEnabled = true;

                e1.Text=selectedFinal.azon.ToString();
                e2.Text=selectedFinal.nev.ToString();
                e3.Text=selectedFinal.szuldatum.ToString();
                e4.Text=selectedFinal.irszam.ToString();
                e5.Text=selectedFinal.orsz.ToString();

            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (databaseGrid.SelectedItem != null)
            {
                string tmp = $"delete from ugyfel where ugyfel.azon like {selectedFinal.azon} and ugyfel.irszam like {selectedFinal.irszam}";
                MySqlConnection ss = new MySqlConnection(sqllink);
                ss.Open();
                MySqlCommand command = new MySqlCommand(tmp, ss);
                command.ExecuteNonQuery();
                ss.Close();
                Beolvas();
            }
        }

        private void s1_TextChanged(object sender, TextChangedEventArgs e)
        {
            CountCheck(s1);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string a1 = s1.Text;
            string a2 = s2.Text;
            string a3 = s3.Text;
            string a4 = s4.Text;
            string a5 = s5.Text;

            if (a1 != "" && a2 != "" && a3 != "" && a4 != "" && a5 != "")
            {
                string tmp = $"INSERT INTO `ugyfel` (`azon`, `nev`, `szuldatum`, `irszam`, `orsz`) VALUES ('{a1}', '{a2}', '{a3}', '{a4}', '{a5}');";
                MySqlConnection ss = new MySqlConnection(sqllink);
                ss.Open();
                MySqlCommand command = new MySqlCommand(tmp, ss);
                command.ExecuteNonQuery();
                ss.Close();
                Beolvas();
                s1.Clear();
                s2.Clear();
                s3.Clear();
                s4.Clear();
                s5.Clear();
            }
        }

        private void s4_TextChanged(object sender, TextChangedEventArgs e)
        {
            CountCheck(s4);
        }

        private void CountCheck(TextBox an)
        {
            try
            {
                int a = int.Parse(an.Text);
            }
            catch (FormatException)
            {
                if (an.Text.Length > 0)
                {
                    // Remove the last character
                    an.Text = an.Text.Substring(0, an.Text.Length - 1);

                    // Move the cursor to the end of the text
                    an.CaretIndex = an.Text.Length;
                }
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            string r1 = e1.Text;
            string r2 = e2.Text;
            string r3 = e3.Text;
            string r4 = e4.Text;
            string r5 = e5.Text;

            string updateQuery1 = $"UPDATE ugyfel SET nev = '{r2}', szuldatum = '{r3}', orsz = '{r5}' WHERE azon = {selectedFinal.azon} And irszam = {selectedFinal.irszam}";
            string updateQuery2 = $"UPDATE ugyfel SET azon = '{r1}', irszam = '{r4}' WHERE nev = {r2} And szuldatum = '{r3}'And orsz = '{r4}' ";

            using (MySqlConnection ss = new MySqlConnection(sqllink))
            {
                ss.Open();
                MySqlCommand command = new MySqlCommand(updateQuery1, ss);
                command.ExecuteNonQuery();
                MySqlCommand commands = new MySqlCommand(updateQuery2, ss);
                command.ExecuteNonQuery();
            }
            Beolvas();
        }
    }
}

/*
 *         <DataGrid x:Name="databaseGrid" Margin="10,110,276,10" SelectedValue="ss" Background="#FFDCFEFF">
            <DataGrid.Columns>
                <DataGridTextColumn Header="azon" Binding="{Binding azon}" Width="*"/>
                <DataGridTextColumn Header="nev" Binding="{Binding nev}" Width="*" />
                <DataGridTextColumn Header="szuldatum" Binding="{Binding szuldatum}" Width="*" />
                <DataGridTextColumn Header="irszam" Binding="{Binding irszam}" Width="*"/>
                <DataGridTextColumn Header="orsz" Binding="{Binding orsz}" Width="*"/>
            </DataGrid.Columns>
        </DataGrid>
 * 
 */
