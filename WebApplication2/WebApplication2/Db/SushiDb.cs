using System;
using System.Linq;
using System.Data.Common;
using System.Reflection;
using WebApplication2.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Db
{
    public class SushiDb : DbContext
    {
        public DbSet<Sushi> SushisDb { get; set; }
    
        public SushiDb(DbContextOptions<SushiDb> options) : base(options)
        {
    
        }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sushi>(entity =>
            {
                entity.ToTable("sushi");
                entity
                    .Property(e => e.Id)
                    .IsRequired();
    
                entity
                    .Property(e => e.Name)
                    .IsRequired();
    
                entity
                    .Property(e => e.Img_url)
                    .IsRequired();
    
                entity
                    .Property(e => e.Created_at)
                    .IsRequired();
                
                entity
                    .Property(e => e.Price)
                    .IsRequired();
            });
        }
    }
}