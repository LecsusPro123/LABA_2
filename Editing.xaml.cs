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


namespace LABA_2._1
{
    /// <summary>
    /// Логика взаимодействия для Editing.xaml
    /// </summary>
    public partial class Editing : Window
    {
        public Editing()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            Id.Text = DataBase.selected.Threat_ID;
            NameOf.Text = DataBase.selected.Threat_Name;
            Desc.Text = DataBase.selected.Threat_Description;
            Sours.Text = DataBase.selected.Threat_Sourse;
            Object.Text = DataBase.selected.Threat_Object;
            conf.Text = DataBase.selected.IsConfidentiality;
            integ.Text = DataBase.selected.IsIntegrity;
            allow.Text = DataBase.selected.IsAvailability;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Идентификатор угрозы: {DataBase.selected.Threat_ID}\n\n" +
                            $"Наименование угрозы: {DataBase.selected.Threat_Name}\n\n" +
                            $"Описание угрозы: {DataBase.selected.Threat_Description}\n\n" +
                            $"Источник угрозы: {DataBase.selected.Threat_Sourse}\n\n" +
                            $"Объект воздействия угрозы: {DataBase.selected.Threat_Object}\n\n" +
                            $"Нарушение конфиденциальности: {DataBase.selected.IsConfidentiality}\n\n" +
                            $"Нарушение целостности: {DataBase.selected.IsIntegrity}\n\n" +
                            $"Нарушение доступности: {DataBase.selected.IsAvailability}\n\n", "БЫЛО"); 

            DataBase.selected.Threat_ID = Id.Text;
            DataBase.selected.Threat_Name = NameOf.Text;
            DataBase.selected.Threat_Description = Desc.Text;
            DataBase.selected.Threat_Sourse = Sours.Text;
            DataBase.selected.Threat_Object = Object.Text;
            DataBase.selected.IsConfidentiality = conf.Text;
            DataBase.selected.IsIntegrity = integ.Text;
            DataBase.selected.IsAvailability = allow.Text;

            MessageBox.Show($"Идентификатор угрозы: {DataBase.selected.Threat_ID}\n\n" +
                            $"Наименование угрозы: {DataBase.selected.Threat_Name}\n\n" +
                            $"Описание угрозы: {DataBase.selected.Threat_Description}\n\n" +
                            $"Источник угрозы: {DataBase.selected.Threat_Sourse}\n\n" +
                            $"Объект воздействия угрозы: {DataBase.selected.Threat_Object}\n\n" +
                            $"Нарушение конфиденциальности: {DataBase.selected.IsConfidentiality}\n\n" +
                            $"Нарушение целостности: {DataBase.selected.IsIntegrity}\n\n" +
                            $"Нарушение доступности: {DataBase.selected.IsAvailability}\n\n", "СТАЛО");

            DataBase.count++;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Note note = DataBase.db.Notes.Where(o => o == DataBase.selected).FirstOrDefault();
            DataBase.db.Notes.Remove(note);
            this.Close();
        }

        private void Ready_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
