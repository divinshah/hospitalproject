using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalNew.Models
{
    public class Schedule
    {
        [Key, ScaffoldColumn(false)]
        public int ScheduleId { get; set; }
        
        //does timestamp store it in unix time?
        //if yes -- just convert it to D m y H: is 
        //if no -- find another data type
        [Required, Timestamp, Display(Name = "Date")]
        public string Date { get; set; }

        [ForeignKey("Staff")]
        public int StaffId { get; set; }

        public virtual Staff staff { get; set; }

        [ForeignKey("Locations")]
        public int locationId { get; set; }

        public virtual Locations location { get; set; }
    }
}
