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
using System.Windows.Shapes;

namespace Trying
{
    /// <summary>
    /// Interaction logic for reg.xaml
    /// </summary>
    public partial class reg : Window
    {
        private sqlclass Sqlss = new sqlclass();

        public reg()
        {
            InitializeComponent();
        }

        private void Regist_Click(object sender, RoutedEventArgs e)
        {
            string felh = username.Text;
            string pass = passworld.Password;

            if(felh.Length!=0 && pass.Length != 0)
            {
                Sqlss.Regist(felh, pass);

                MainWindow login = new MainWindow();
                login.Show();
                this.Close();

                MessageBox.Show("You succesfully regisrated!");
            }
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            if (Sqlss.Checker())
            {
                MainWindow login = new MainWindow();
                login.Show();
                this.Close();
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
