using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalNew.Models.ViewModels
{
    public class VolunteerEdit
    {

        public VolunteerEdit()
        {

        }
        // list of volunteer

        public virtual Volunteer Volunteer { get; set; }

        public IEnumerable<Hospital> Hospitals { get; set; }


    }
}
