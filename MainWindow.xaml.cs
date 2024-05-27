using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Trying
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        sqlclass sql = new sqlclass();

        public MainWindow()
        {
            InitializeComponent();

            SQLBOX sQLBOX = new SQLBOX();
            sQLBOX.Show();
            this.Close();


            /*
            if (!sql.Checker())
            {
                reg();
            }*/

        }

        private void regist_Click(object sender, RoutedEventArgs e)
        {
            reg();
        }


        private void reg()
        {
            reg reg = new reg();
            reg.Show();
            this.Close();
        }


        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string name = username.Text; 
            string pass = passworld.Password;
            if(sql.Login(name, pass))
            {
                MessageBox.Show("Acces Granted");
                SQLBOX sQLBOX = new SQLBOX();
                sQLBOX.Show();
                this.Close();
            }
            else 
            {
                MessageBox.Show("Acces Denied");
            }
            
        }
    }
}
