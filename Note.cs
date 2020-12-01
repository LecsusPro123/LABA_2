using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA_2._1
{
    public class Note
    {
        private string threat_ID, threat_Name, threat_Description, threat_Sourse, threat_Object, isConfidentiality, isIntegrity, isAvailability;
        public int Id { get; set; }
        public string Threat_ID
        {
            get { return threat_ID; }
            set {threat_ID = "УБИ." + value.Replace("УБИ.", "").PadLeft(3, '0'); }
        }
        public string Threat_Name
        {
            get { return threat_Name; }
            set { threat_Name = value; }
        }
        public string Threat_Description
        {
            get { return threat_Description; }
            set { threat_Description = value; }
        }
        public string Threat_Sourse
        {
            get { return threat_Sourse; }
            set { threat_Sourse = value; }
        }
        public string Threat_Object
        {
            get { return threat_Object; }
            set { threat_Object = value; }
        }
        public string IsConfidentiality
        {
            get { return isConfidentiality; }
            set { isConfidentiality = (value == "1" || value == "да") ? "да" : "нет"; }
        }
        public string IsIntegrity
        {
            get { return isIntegrity; }
            set { isIntegrity = (value == "1" || value == "да") ? "да" : "нет"; }
        }
        public string IsAvailability
        {
            get { return isAvailability; }
            set { isAvailability = (value == "1" || value == "да") ? "да" : "нет"; }
        }

        public Note() { }

        public Note(string Threat_ID, string Threat_Name, string Threat_Description, string Threat_Sourse,
                        string Threat_Object, string IsConfidentiality, string IsIntegrity, string IsAvailability)
        {
            this.Threat_ID = Threat_ID;
            this.Threat_Name = Threat_Name;
            this.Threat_Description = Threat_Description;
            this.Threat_Sourse = Threat_Sourse;
            this.Threat_Object = Threat_Object;
            this.IsConfidentiality = IsConfidentiality;
            this.IsIntegrity = IsIntegrity;
            this.IsAvailability = IsAvailability;
        }
    }
}
   
