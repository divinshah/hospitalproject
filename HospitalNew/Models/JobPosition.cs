using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalNew.Models
{
    public class JobPosition
    {

        [Key, ScaffoldColumn(false)]
        public int JobID { get; set; }


        // QUESTION FOR GROUP: IS SOMEONE DOING DEPARTMENTS?
        [Required, StringLength(255), Display(Name = "HospitalTitle")]
        public string HospitalTitle { get; set; }

        [Required, StringLength(255), Display(Name = "Title")]
        public string JobTitle { get; set; }

        [Required, StringLength(255), Display(Name = "Type")]
        public string JobType { get; set; } //This talks about partime, fulltime, etc.

        [StringLength(int.MaxValue), Display(Name = "Description")]
        public string JobDesc { get; set; }

        [StringLength(int.MaxValue), Display(Name = "Requirements")]
        public string JobReq { get; set; }

        //a job position has many applications
        public virtual IEnumerable<JobApplication> jobapplications { get; set; }


        // job has one hospital
        public virtual Hospital Hospital { get; set; }

        [ForeignKey("Hospital")]
        public int HospitalID { get; set; }

        //job has one department
        public virtual Department Department { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }



        [ForeignKey("JobApplication")]
        public int JobApplicationID { get; set; }

        IEnumerable<JobApplication> JobApplications { get; set; }
    }

}

