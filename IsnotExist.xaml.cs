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
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Net;


namespace LABA_2._1
{
    /// <summary>
    /// Логика взаимодействия для IsnotExist.xaml
    /// </summary>
    public partial class IsnotExist : Window
    {
        public IsnotExist()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WebClient webload = new WebClient();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            string folder = "";

            try
            {
                if (saveFileDialog.ShowDialog() == true)
                    folder = saveFileDialog.FileName;

                webload.DownloadFileAsync(new Uri("https://bdu.fstec.ru/files/documents/thrlist.xlsx"), folder);
                MessageBox.Show("Файл скачен!\n Идет создания локальной базы данных...", "Успех");
            }
            catch (Exception exp)
            {

                MessageBox.Show($"{exp.Message}", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            

            ExelReader.urlDirection = folder;
            DataBase dataBase = new DataBase();
            this.Hide();
            dataBase.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

            try
            {
                if (openFileDialog.ShowDialog() == true)
                    ExelReader.urlDirection = openFileDialog.FileName;
                MessageBox.Show("Идет создания локальной базы данных...", "Успех");
            }
            catch (Exception exp)
            {

                MessageBox.Show($"{exp.Message}", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            DataBase dataBase = new DataBase();
            this.Hide();
            dataBase.Show();
            this.Close();
        }
    }
}
