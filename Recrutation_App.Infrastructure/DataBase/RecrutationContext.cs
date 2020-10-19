using Microsoft.EntityFrameworkCore;
using Recrutation_App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recrutation_App.Infrastructure.DataBase
{
    public class RecrutationContext : DbContext
    {
        public RecrutationContext(DbContextOptions<RecrutationContext> options) : base(options)
        { }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Employees)
                .WithOne(e => e.Company)
                .HasForeignKey(e=>e.CompanyId);
        }
    }
}
