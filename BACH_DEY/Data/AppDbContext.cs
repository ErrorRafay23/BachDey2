using BACH_DEY.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACH_DEY.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
     //   private readonly DbContextOptions _options;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = string.Format(@"Server=DESKTOP-59QOFNR\SQLEXPRESS; Database=BachDeyDB2; Trusted_Connection=True; MultipleActiveResultSets=true");
            optionsBuilder.UseSqlServer(connectionString);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           // modelBuilder.Seed();

        }


        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Product> products { get; set; } 
        
    }
}
