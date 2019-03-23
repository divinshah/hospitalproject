using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalNew.Models.ViewModels
{
    public class JobPositionEdit
    {
        public JobPositionEdit()
        {

        }
       // list of hospitals

        public virtual JobPosition JobPosition { get; set; }

        public IEnumerable<Hospital> Hospitals { get; set; }

        public IEnumerable<Resume> Resumes { get; set; }
    }

}
