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
    public class Volunteer
    {
        [Key]
        public int VolunteerID { get; set; }

        [Required, StringLength(255), Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required, StringLength(255), Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required, StringLength(255), Display(Name = "MiddleName")]
        public string Middle { get; set; }

        [Required, StringLength(255), Display(Name = "City")]
        public string City { get; set; }

        [Required, StringLength(255), Display(Name = "Province")]
        public string Province { get; set; }

        [Required, StringLength(255), Display(Name = "Zip")]
        public string Zip { get; set; }

        [Required, StringLength(255), Display(Name = "Phone")]
        public string Phone { get; set; }

        [Required, StringLength(255), Display(Name = "Email")]
        public string Email { get; set; }

        [Required, StringLength(255), Display(Name = "Age")]
        public string Age { get; set; }

        [Required, StringLength(255), Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required, StringLength(255), Display(Name = "Education")]
        public string Education { get; set; }

        [Required, StringLength(255), Display(Name = "Experience")]
        public string Experience { get; set; }

        [Required, StringLength(255), Display(Name = "Availability")]
        public string Availability { get; set; }

        [Required, StringLength(255), Display(Name = "Name")]
        public string Name { get; set; }

        [Required, StringLength(255), Display(Name = "Phone_em")]
        public string Phone_em { get; set; }

        [Required, StringLength(255), Display(Name = "RelationShip")]
        public string Relationship { get; set; }

        [Required, StringLength(255), Display(Name = "HealthCondition")]
        public string HealthCondition { get; set; }

        [ForeignKey("hospital")]
        public int HospitalID { get; set; }

        public virtual Hospital Hospital { get; set; }




    }
}

//mmmmmm