using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalNew.Models
{
    public class Locations
    {
        [Key, ScaffoldColumn(false)]
        public int LocationId { get; set; }

        [Required, StringLength(255), Display(Name = "LocationName")]
        public string LocationName { get; set; }

        [Required, StringLength(255), Display(Name = "LocationAddress")]
        public string LocationAddress { get; set; }

        public virtual Schedule schedule { get; set; }
    }
}
