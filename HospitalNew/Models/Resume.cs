using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HospitalNew.Models
{
    public class Resume
    {
        [Key, ScaffoldColumn(false)]
        public int ResumeID { get; set; }

        [Required, StringLength(255), Display(Name = "Job Position")]
        public string JobTitle { get; set; }

        [Required, StringLength(255), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(255), Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required, StringLength(255), Display(Name = "Email")]
        public string Email { get; set; }

        [Required, StringLength(255), Display(Name = "Phone")]
        public string Phone { get; set; }

        [StringLength(int.MaxValue), Display(Name = "Cover Letter")]
        public string CoverLetter { get; set; }

        [StringLength(int.MaxValue), Display(Name = "Resume")]
        public string Summary { get; set; }

        public virtual ICollection<JobPositionxResume> jobpositionsxresumes { get; set; }
    }
}
