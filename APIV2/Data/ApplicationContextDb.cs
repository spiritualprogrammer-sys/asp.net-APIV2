using System;
using APIV2.Models;
using Microsoft.EntityFrameworkCore;

namespace APIV2.Data;

public class ApplicationContextDb : DbContext
{

    public ApplicationContextDb(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<Stocks> Stocks { get; set; }

    public DbSet<Comments> Comments { get; set; }   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration explicite de la relation
        /*    modelBuilder.Entity<Stocks>()
                .HasMany(s => s.Comments)
                .WithOne(c => c.Stocks)
                .HasForeignKey(c => c.StockId)
                .OnDelete(DeleteBehavior.Cascade); */
        }
    
}
