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

        [Required, StringLength(255), Display(Name = "HospitalTitle")]
        public string HospitalTitle { get; set; }

        [Required, StringLength(255), Display(Name = "Title")]
        public string JobTitle { get; set; }

        [Required, StringLength(255), Display(Name = "Category")]
        public string Category { get; set; }

        [Required, StringLength(255), Display(Name = "Type")]
        public string JobType { get; set; }

        [StringLength(int.MaxValue), Display(Name = "Description")]
        public string JobDesc { get; set; }

        [StringLength(int.MaxValue), Display(Name = "Requirements")]
        public string JobReq { get; set; }

        [Required, StringLength(255), Display(Name = "Deadline")]
        public string Deadline { get; set; }

        //JobPosition has hospital ID
        [ForeignKey("HospitalID")]
        public int HospitalID { get; set; }
        //Blog Author
        public virtual Hospital Hospital { get; set; }
    }
}