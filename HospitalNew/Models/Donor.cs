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
    public class Donor
    {
        [Key]
        public int DonorID { get; set; }

        [Required, StringLength(255), Display(Name = "Name")]
        public string DonorName { get; set; }

        [Required, StringLength(2000), Display(Name = "Message")]
        public string DonorMessage { get; set; }
    }
}
