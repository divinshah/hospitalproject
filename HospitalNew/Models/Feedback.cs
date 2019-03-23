using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalNew.Models
{
    public class Feedback
    {
        [Key]
        public int FeedbackID { get; set; }

        [Required, StringLength(255), Display(Name = "Question")]
        public string FeedbackQues { get; set; }
    }
}
