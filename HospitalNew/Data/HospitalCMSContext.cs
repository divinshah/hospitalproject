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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            //describing that a hospitalxjobposition PK is composite of hospital and job
            modelBuilder.Entity<HospitalxJobPosition>()
                .HasKey(pxt => new { pxt.HospitalID, pxt.JobID });

            //describing that hospitalxjobposition is associated with one hospital
            //AND one page has many hospitalsxjobpositions
            //AND hospitalsxjobpositions has foreign key to hospitalid
            modelBuilder.Entity<HospitalxJobPosition>()
                .HasOne(pxt => pxt.Hospital)
                .WithMany(pxt => pxt.hospitalsxjobpositions)
                .HasForeignKey(pxt => pxt.HospitalID);

            //Describing that hospitalxjobposition is associated to one position
            //AND one position has many hospitalsxjobpositions
            //and hospitalsxjobpositions has foreign key to jobid
            modelBuilder.Entity<HospitalxJobPosition>()
                .HasOne(pxt => pxt.JobPosition)
                .WithMany(pxt => pxt.hospitalsxjobpositions)
                .HasForeignKey(pxt => pxt.JobID);


            base.OnModelCreating(modelBuilder);
            //also need to specify that these models make tables
            modelBuilder.Entity<Hospital>().ToTable("Hospitals");
            modelBuilder.Entity<JobPosition>().ToTable("JobPositions");
            modelBuilder.Entity<HospitalxJobPosition>().ToTable("HospitalsxJobPositions");


        }
    }
}
