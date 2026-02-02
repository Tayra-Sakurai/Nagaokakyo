using Kizu.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kizu.Contexts
{
    public class KizuContext : DbContext
    {
        public DbSet<Table> Tables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                "Data Source=Kizu.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>(
                t =>
                {
                    t.ToTable("Tables");
                    t.HasKey(e => e.Id);
                    t.Property(e => e.DateTime)
                    .HasColumnType("TEXT")
                    .IsRequired();
                    t.Property(e => e.Item)
                    .HasColumnType("TEXT")
                    .IsRequired();
                    t.Property(e => e.Cash)
                    .HasColumnType("INTEGER")
                    .HasDefaultValue(0)
                    .IsRequired();
                    t.Property(e => e.Icoca)
                    .HasColumnType("INTEGER")
                    .HasDefaultValue(0)
                    .IsRequired();
                    t.Property(e => e.Nanaco)
                    .HasColumnType("INTEGER")
                    .HasDefaultValue(0)
                    .IsRequired();
                    t.Property(e => e.Coop)
                    .HasColumnType("INTEGER")
                    .HasDefaultValue(0)
                    .IsRequired();
                }
            );
        }
    }
}
