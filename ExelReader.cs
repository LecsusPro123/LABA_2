using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Windows;

namespace LABA_2._1
{
    public class ExelReader
    {
        static public string urlDirection { get; set; } = Directory.GetCurrentDirectory() + "\\thrlist.xlsx";
        static public AppContext  ExcelReading() 
        {
            AppContext db = new AppContext();
            db.Notes.RemoveRange(db.Notes);
            db.SaveChanges();

            Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@urlDirection);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                int i = 3;
                while (xlRange.Cells[i, 1] != null && xlRange.Cells[i, 1].Value2 != null)
                {
                    Note note = new Note();
                    if (xlRange.Cells[i, 1] != null && xlRange.Cells[i, 1].Value2 != null)
                    {
                        note.Threat_ID = xlRange.Cells[i, 1].Value2.ToString();
                        note.Threat_Name = xlRange.Cells[i, 2].Value2.ToString();
                        note.Threat_Description = xlRange.Cells[i, 3].Value2.ToString();
                        note.Threat_Sourse = xlRange.Cells[i, 4].Value2.ToString();
                        note.Threat_Object = xlRange.Cells[i, 5].Value2.ToString();
                        note.IsConfidentiality = xlRange.Cells[i, 6].Value2.ToString();
                        note.IsIntegrity = xlRange.Cells[i, 7].Value2.ToString();
                        note.IsAvailability = xlRange.Cells[i, 8].Value2.ToString();
                    }
                    db.Notes.Add(note);
                    i++;
                }
                db.SaveChanges();
            xlWorkbook.Close();
            return db;
        }

    }
}
