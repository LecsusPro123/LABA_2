using System;
using System.Collections.Generic;
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

namespace LABA_2._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (System.IO.File.Exists("thrlist.xlsx"))
            {
                DataBase dataBase = new DataBase();
                this.Hide();
                dataBase.Show();
                this.Close();
            }
            else
            {
                IsnotExist isnotExist = new IsnotExist();
                this.Hide();
                isnotExist.Show();
                this.Close();
            }
        }
    }
}
