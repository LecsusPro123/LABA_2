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
using System.Data.Entity;
using ExporterObjects;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;

namespace LABA_2._1
{
   
    /// <summary>
    /// Логика взаимодействия для DataBase.xaml
    /// </summary>
    public partial class DataBase : Window
    {
        public static AppContext db;
        int scr_val = 0;
        public static int count = 0;
        public static Note selected = null;
        public DataBase()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            //db.Notes.RemoveRange(db.Notes);
            //db.SaveChanges();
            db = ExelReader.ExcelReading();
            //db = new AppContext();
            db.Notes.Load(); 
            notesGrid.ItemsSource = db.Notes.Local.Skip(scr_val).Take(15);
            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if (notesGrid.SelectedItems.Count > 0)
                for (int i = 0; i < notesGrid.SelectedItems.Count; i++)
                    selected = notesGrid.SelectedItems[i] as Note;

            Editing editing = new Editing();
            editing.Show();
        }

        private void ToPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (scr_val >= 0)
            {
                scr_val = scr_val - 15;
                notesGrid.ItemsSource = db.Notes.Local.Skip(scr_val).Take(15);                
            }
        }

        private void ToNext_Click(object sender, RoutedEventArgs e)
        {
            if (scr_val <= 0) scr_val = 0;

            if (scr_val + 15 < db.Notes.Count())
            {
                scr_val = scr_val + 15;
                notesGrid.ItemsSource = db.Notes.Local.Skip(scr_val).Take(15);
            }
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (notesGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < notesGrid.SelectedItems.Count; i++)
                {
                    selected = notesGrid.SelectedItems[i] as Note;
                    if (selected != null)
                    {
                        MessageBox.Show($"Идентификатор угрозы: {selected.Threat_ID}\n\n" +
                                        $"Наименование угрозы: {selected.Threat_Name}\n\n" +
                                        $"Описание угрозы: {selected.Threat_Description}\n\n" +
                                        $"Источник угрозы: {selected.Threat_Sourse}\n\n" +
                                        $"Объект воздействия угрозы: {selected.Threat_Object}\n\n" +
                                        $"Нарушение конфиденциальности: {selected.IsConfidentiality}\n\n" +
                                        $"Нарушение целостности: {selected.IsIntegrity}\n\n" +
                                        $"Нарушение доступности: {selected.IsAvailability}\n\n");
                    }
                }
            }
        }

        private void updateDataBase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db.SaveChanges();
                MessageBox.Show($"{count} записей обновлено", "Успешно");
                count = 0;
            }
            catch (Exception exp)
            {
                MessageBox.Show($"{exp.Message}", "Alert", MessageBoxButton.OK, MessageBoxImage.Information); 
            }
            
        }

        public void Update_Click(object sender, RoutedEventArgs e)
        {
            notesGrid.ItemsSource = db.Notes.Local.Skip(scr_val).Take(15);
        }

        private void ExportToExcelButton_Click(object sender, RoutedEventArgs e)
        {
            List<Note> list = db.Notes.ToList();
            ExportList<Note> exp = new ExportList<Note>();

            MessageBox.Show("Готово файл сохранился в текущей папке!!!");

            exp.PathTemplateFolder = Directory.GetCurrentDirectory();


            exp.ExportTo(list, ExportToFormat.Excel2007, "result.xlsx");
        }
    }
}