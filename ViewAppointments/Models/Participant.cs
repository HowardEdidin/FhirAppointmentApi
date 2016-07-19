using System;
using System.Collections.Generic;

namespace ViewAppointments.Models
{
    [Serializable]
    public class Participant
    {
        
        public IList<Actor> Actor { get; set; }

        public string Status { get; set; }

        public string Required { get; set; }

        //public IList<Type> Type { get; set; }
    }
}