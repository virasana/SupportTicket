using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using ST.SharedEntitiesLib;

namespace ST.SQLServerRepoLib
{
    public class SupportTicketDbContext : DbContext
    {
        private readonly string _connectionString;

        public SupportTicketDbContext(DbContextOptions<SupportTicketDbContext> options) : base(options) { }
        public SupportTicketDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Severity> Severity { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Severity>(entity =>
            {
                entity.Property(e => e.DisplayName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(t => t.TicketId)
                    .IsRequired();

                entity.HasKey(p => p.TicketId);

                entity.HasIndex(e => e.TicketId)
                    .HasName("IX_TicketId");

                entity.HasIndex(e => e.ProductId)
                    .HasName("IX_ProductId");

                entity.HasIndex(e => e.SeverityId)
                    .HasName("IX_SeverityId");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Problem)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.TimeStamp)
                    .IsRequired()
                    .IsRowVersion();

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_dbo.Ticket_dbo.Product_ProductId");

                entity.HasOne(d => d.Severity)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.SeverityId)
                    .HasConstraintName("FK_dbo.Ticket_dbo.Severity_SeverityId");
            });
        }
    }
}
