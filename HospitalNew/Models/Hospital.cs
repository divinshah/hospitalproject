using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalNew.Models
{
    public class Hospital
    {
        //Many hospitals to many jobpositions

        [Key, ScaffoldColumn(false)]
        public int HospitalID { get; set; }

        [Required, StringLength(255), Display(Name = "Title")]
        public string HospitalTitle { get; set; }

        [Required, StringLength(255), Display(Name = "Address")]
        public string Address { get; set; }

        [Required, StringLength(255), Display(Name = "Email")]
        public string Email { get; set; }

        [Required, StringLength(255), Display(Name = "Phone")]
        public string Phone { get; set; }

        [StringLength(int.MaxValue), Display(Name = "Description")]
        public string Description { get; set; }

        [StringLength(int.MaxValue), Display(Name = "Department")]
        public string Department { get; set; }


        //Hospital and Job Positions


        //Accepted image formats (jpg/jpeg/png/gif)
        public string ImgType { get; set; }

        public int HasPic { get; set; }

        [InverseProperty("Hospital")]
        public List<JobPosition> JobPositions { get; set; }

        //one hospital has many departments
        public IEnumerable<Department> Departments { get; set; }

        //one hospital has many volunteers
        public IEnumerable<Volunteer> Volunteers { get; set; }


        //foreign key
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        [ForeignKey("Volunteer")]
        public int VolunteerID { get; set; }

        [ForeignKey("JobPosition")]
        public int JobPositionID { get; set; }


    }
}
