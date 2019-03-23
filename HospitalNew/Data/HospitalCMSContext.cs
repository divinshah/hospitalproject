using System;
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
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Feedback> Feedback { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Feedback>().ToTable("Feedback");
            //Hospital has many jobpositions, each position has one hospital
            modelBuilder.Entity<JobPosition>()
                .HasOne(b => b.Hospital)
                .WithMany(a => a.JobPositions)
                .HasForeignKey(b => b.HospitalID);

            modelBuilder.Entity<JobPositionxResume>()
                .HasKey(pxt => new { pxt.JobID, pxt.ResumeID });

            modelBuilder.Entity<JobPositionxResume>()
                .HasOne(pxt => pxt.JobPosition)
                .WithMany(pxt => pxt.jobpositionsxresumes)
                .HasForeignKey(pxt => pxt.JobID);


            modelBuilder.Entity<JobPositionxResume>()
                .HasOne(pxt => pxt.Resume)
                .WithMany(pxt => pxt.jobpositionsxresumes)
                .HasForeignKey(pxt => pxt.ResumeID);


            //includes








            base.OnModelCreating(modelBuilder);
            //also need to specify that these models make tables
            modelBuilder.Entity<Hospital>().ToTable("Hospitals");
            modelBuilder.Entity<JobPosition>().ToTable("JobPositions");
            modelBuilder.Entity<Resume>().ToTable("Resumes");
            modelBuilder.Entity<JobPositionxResume>().ToTable("jobositionsxresumes");

        }
    }
}
