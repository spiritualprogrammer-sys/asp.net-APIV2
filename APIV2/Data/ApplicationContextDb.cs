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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
