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

//We are also using Entity Framework Core, so make sure you have these dependencies.
//https://learnentityframeworkcore.com


namespace HospitalNew.Models
{
    public class HospitalNewContext : IdentityDbContext<ApplicationUser>
    {
        public HospitalNewContext (DbContextOptions<HospitalNewContext> options)
            : base(options)
        {
        }

        public DbSet<Feedback> Feedback { get; set; }


        public DbSet<Staff> stuff { get; set; }
        public DbSet<Locations> location { get; set; }
        public DbSet<Schedule> schedule { get; set; }
        public DbSet<Alert> alert { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>().ToTable("Stuff");
            modelBuilder.Entity<Locations>().ToTable("Locations");
            modelBuilder.Entity<Schedule>().ToTable("Schedule");
            modelBuilder.Entity<Alert>().ToTable("Alert");


            modelBuilder.Entity<Feedback>().ToTable("Feedback");
            base.OnModelCreating(modelBuilder);
        }

        

    }

    
}
