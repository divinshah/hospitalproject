using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalNew.Models
{
    public class JobApplication
    {
        [Key, ScaffoldColumn(false)]
        public int JobApplicationID { get; set; }

        /*
         *  QUESTION FOR GROUP: IS SOMEONE DOING DEPARTMENTS?
        [Required, StringLength(255), Display(Name = "Department")]
        public string Department { get; set; }
        */

        [Required, StringLength(255), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(255), Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, StringLength(255), Display(Name = "Email")]
        public string Email { get; set; }

        [Required, StringLength(255), Display(Name = "Phone")]
        public string Phone { get; set; }

        //consider a file upload instead of plain text
        [StringLength(int.MaxValue), Display(Name = "Cover Letter")]
        public string CoverLetter { get; set; }

        //consider a file upload instead of plain text
        [StringLength(int.MaxValue), Display(Name = "Resume")]
        public string Summary { get; set; }

        //we decided that a jobposting is for one job only
        public virtual JobPosition jobposition { get; set; }

        [ForeignKey("JobPosition")]
        public int JobPositionID { get; set; }

        [ForeignKey("Hospital")]
        public int HospitalID { get; set; }
    }
}
