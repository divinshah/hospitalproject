﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using HospitalNew.Models;

namespace HospitalNew.Data
{
    public class HospitalCMSContext : IdentityDbContext<ApplicationUser>
    {
        public HospitalCMSContext(DbContextOptions<HospitalCMSContext> options)
        : base(options)
        {

        }


        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<JobPosition> JobPositions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Hospital has many jobpositions, each position has one hospital
            modelBuilder.Entity<JobPosition>()
                .HasOne(b => b.Hospital)
                .WithMany(a => a.JobPositions)
                .HasForeignKey(b => b.HospitalID);






            base.OnModelCreating(modelBuilder);
            //also need to specify that these models make tables
            modelBuilder.Entity<Hospital>().ToTable("Hospitals");
            modelBuilder.Entity<JobPosition>().ToTable("JobPositions");
            


        }
    }
}
