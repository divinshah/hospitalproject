using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalNew.Models
{
    public class Staff
    {
        [Key, ScaffoldColumn(false)]
        public int StaffId { get; set; }

        [Required, StringLength(255), Display(Name = "First Name")]
        public string StaffFirstName { get; set; }

        [Required, StringLength(255), Display(Name = "Last Name")]
        public string StaffLastName { get; set; }

        [Required, StringLength(255), Display(Name = "Position")]
        public string StaffPosition { get; set; }

        [Required, StringLength(255), Display(Name = "Department")]
        public string StaffDepartment { get; set; }


        //in schedules we have foreign key pointing to staff,
        //this implies that one staff has many schedules
        //however, we need to say this explicitly with the inverseproperty.
        [InverseProperty("Staff")]
        public List<Schedule> Schedules { get; set; }

        //TODO: Merge with Departments 
        //[ForeignKey("departmentID")]
        //public int departmentid { get; set; }
        //public virtual Department department { get; set; }





  
    }
}
