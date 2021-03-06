﻿using System;
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


        //Hospital and Job Positions
        public virtual JobPosition JobPosition { get; set; }

        //Accepted image formats (jpg/jpeg/png/gif)
        public string ImgType { get; set; }

        public int HasPic { get; set; }

        [InverseProperty("Hospital")]
        public List<JobPosition> JobPositions { get; set; }
    }
}
