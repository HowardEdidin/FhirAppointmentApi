using System;
using System.Collections.Generic;

namespace ViewAppointments.Models
{
    [Serializable]
    public class Type
    {
        public IList<Coding> Coding { get; set; }
    }
}