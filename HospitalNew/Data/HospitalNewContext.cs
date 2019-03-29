using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

//We are also using Entity Framework Core, so make sure you have these dependencies.
//https://learnentityframeworkcore.com
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;


namespace HospitalNew.Models
{
    public class HospitalNewContext : IdentityDbContext<ApplicationUser>
    {
        public HospitalNewContext (DbContextOptions<HospitalNewContext> options)
            : base(options)
        {
        }

        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<JobPosition> JobPositions { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Department> Departments { get; set; }
        //public DbSet<BookingApp> BookingApps { get; set; }
        public DbSet<Feedback> Feedback { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //following the diagram on the notebook (picture included in assets folder)

            modelBuilder.Entity<JobApplication>()
                .HasOne(j => j.jobposition)
                .WithMany(ja => ja.jobapplications)
                .HasForeignKey(j => j.JobPositionID);

            //QUESTION FOR GROUP: IS SOMEONE DOING DEPARTMENTS? ans:No

            //eash job position references one hospital, one hospital has many job position

            modelBuilder.Entity<JobPosition>()
                .HasOne(h => h.Hospital)
                .WithMany(j => j.JobPositions)
                .HasForeignKey(h => h.HospitalID);

            //each volunteer references one hospital, one hospital has many volunteer

            modelBuilder.Entity<Volunteer>() //WE ARE TALKING ABOUT VOLUNTEERS
                .HasOne(v => v.Hospital) //WE ARE TALKING ABOUT HOSPITALS
                .WithMany(h => h.Volunteers)
                .HasForeignKey(v => v.HospitalID);

            //each job position has one department, each department has many job
            modelBuilder.Entity<JobPosition>()
                .HasOne(d => d.Department)
                .WithMany(j => j.JobPositions)
                .HasForeignKey(d => d.DepartmentID);


            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Feedback>().ToTable("Feedback");
            modelBuilder.Entity<Hospital>().ToTable("Hospitals");
            modelBuilder.Entity<JobPosition>().ToTable("JobPositions");
            modelBuilder.Entity<JobApplication>().ToTable("JobApplications");
            modelBuilder.Entity<Volunteer>().ToTable("Volunteers");
            modelBuilder.Entity<Department>().ToTable("Departments");
        }

    }

    
}
