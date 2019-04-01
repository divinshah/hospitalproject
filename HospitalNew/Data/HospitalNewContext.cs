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
using HospitalNew.Models;


namespace HospitalNew.Models
{
    public class HospitalNewContext : IdentityDbContext<ApplicationUser>
    {
        public HospitalNewContext (DbContextOptions<HospitalNewContext> options)
            : base(options)
        {
        }

        public DbSet<Feedback> Feedback { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Feedback>().ToTable("Feedback");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<HospitalNew.Models.Parking> Parking { get; set; }
        public DbSet<HospitalNew.Models.Donor> Donor { get; set; }

    }

    
}
