using Kizu.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kizu.Contexts
{
    public class KizuContext2 : DbContext
    {
        public DbSet<Table> Tables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Kizu;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>(
                t =>
                {
                    t.ToTable("Tables");
                    t.HasKey(e => e.Id);
                    t.Property(e => e.Item)
                    .IsRequired()
                    .HasColumnType("ntext");
                    t.Property(e => e.DateTime)
                    .IsRequired()
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("getdate()");
                    t.Property(e => e.Cash)
                    .HasColumnType("int")
                    .HasDefaultValue(0);
                    t.Property(e => e.Icoca)
                    .HasColumnType("int")
                    .HasDefaultValue(0);
                    t.Property(e => e.Nanaco)
                    .HasColumnType("int")
                    .HasDefaultValue(0);
                    t.Property(e => e.Coop)
                    .HasColumnType("int")
                    .HasDefaultValue(0);
                }
            );
        }
    }
}
