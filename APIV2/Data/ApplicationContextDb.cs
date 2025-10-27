using System;
using APIV2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APIV2.Data;

public class ApplicationContextDb : IdentityDbContext<AppUser>
{

    public ApplicationContextDb(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<Stocks> Stocks { get; set; }

    public DbSet<Comments> Comments { get; set; }   

     public DbSet<Portfolio> Portfolios { get; set; }   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          // cléf primaire composer
            modelBuilder.Entity<Portfolio>().HasKey(p => new {p.AppUserId, p.StockId}) ;

            modelBuilder.Entity<Portfolio>()
            .HasOne(p => p.AppUser)
            .WithMany(p => p.portfolios)
            .HasForeignKey(p => p.AppUserId);

            modelBuilder.Entity<Portfolio>()
            .HasOne(p => p.Stock)
            .WithMany(p => p.portfolios)
            .HasForeignKey(p => p.StockId);            

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                
                new IdentityRole
                {
                    Id = "2",
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles) ;
        }
    
}
