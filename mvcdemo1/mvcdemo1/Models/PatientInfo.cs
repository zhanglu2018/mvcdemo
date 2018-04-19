using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcdemo1.Models
{
    public class PatientInfo
    {
        public int id { get; set; }
        public string name { get; set; }
        public string sex { get; set; }
        public string age { get; set; }
        public string department { get; set; }
    }
}