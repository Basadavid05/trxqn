using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Trying
{
    /// <summary>
    /// Interaction logic for SQLBOX.xaml
    /// </summary>
    public partial class SQLBOX : Window
    {
        class Zene
        {
            public string azon { get; set; }
            public string nev { get; set; }
            public string szuldatum { get; set; }
            public string irszam { get; set; }
            public string orsz { get; set; }
        }


        sqlclass s=new sqlclass();

        public SQLBOX()
        {
            InitializeComponent();
            SqlFULL();
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            string a1 = s1.Text;
            string a2 = s2.Text;
            string a3 = s3.Text;
            string a4 = s4.Text;
            string a5 = s5.Text;

            if(a1!="" && a2 != "" && a3 != "" && a4 != "" && a5 != "")
            {
                s.Ql(a1, a2, a3, a4, a5);
                SqlFULL();
                s1.Clear();
                s2.Clear();
                s3.Clear();
                s4.Clear();
                s5.Clear();
            }
        }

        private void SqlFULL()
        {
            databaseGrid.Items.Clear();
            string[] lines = s.SQLREAD();
            sqls(lines);
        }


        private void sqls(string[] lines)
        {
            List<Zene> zener = new List<Zene>();
            for (int i = 0; i < lines.Length; i++)
            {
                string[] dmy = lines[i].Split(';');
                Zene a = new Zene();
                a.azon = dmy[0];
                a.nev = dmy[1];
                a.szuldatum = dmy[2];
                a.irszam = dmy[3];
                a.orsz = dmy[4];
                zener.Add(a);
                databaseGrid.Items.Add(zener[i]);
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int a = databaseGrid.SelectedIndex;

            var an = databaseGrid.SelectedItem;
            var s = databaseGrid.ItemsSource;
            MessageBox.Show(s.ToString());
            //s.DL(a);
            SqlFULL();
        }
    }
}
