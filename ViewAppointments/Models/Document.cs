using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewAppointments.Models
{
    public class Document
    {
     

        // ReSharper disable once InconsistentNaming
        public string id { get; set; }

        public string Status { get; set; }

        public int Priority { get; set; }

        public string Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Comment { get; set; }

   
        public DateTime TimeStamp { get; set; }

        public bool HasAttachment { get; set; }
    }
}