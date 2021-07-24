using System;
using Auftragsverwaltung.Data.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Auftragsverwaltung.Data
{
    public partial class OldAuftragDbContext : DbContext
    {
        public OldAuftragDbContext()
        {
        }

        public OldAuftragDbContext(DbContextOptions<OldAuftragDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artikel> Artikel { get; set; }
        public virtual DbSet<Auftrag> Auftrag { get; set; }
        public virtual DbSet<AuftragsPositionen> AuftragsPositionen { get; set; }
        public virtual DbSet<Kunde> Kunde { get; set; }
        public virtual DbSet<Lieferant> Lieferant { get; set; }
        public virtual DbSet<Rechnung> Rechnung { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=192.168.1.34;database=AuftragDB;user id=sa;password=php5java2");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artikel>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PreisNetto).HasColumnType("money");
            });

            modelBuilder.Entity<Auftrag>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Betrag).HasColumnType("money");

                entity.Property(e => e.Datum).HasColumnType("date");

                entity.HasOne(d => d.Kunde)
                    .WithMany(p => p.Auftrag)
                    .HasForeignKey(d => d.KundeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Auftrag_Kunde");

                entity.HasOne(d => d.Rechnung)
                    .WithMany(p => p.Auftrag)
                    .HasForeignKey(d => d.RechnungId)
                    .HasConstraintName("FK_Auftrag_Rechnung");
            });

            modelBuilder.Entity<AuftragsPositionen>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Auftrag)
                    .WithMany(p => p.AuftragsPositionen)
                    .HasForeignKey(d => d.AuftragId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuftragsPositionen_Auftrag");
            });

            modelBuilder.Entity<Kunde>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nachname).HasMaxLength(100);

                entity.Property(e => e.Ort).HasMaxLength(100);

                entity.Property(e => e.Plz).HasMaxLength(10);

                entity.Property(e => e.Strasse).HasMaxLength(100);

                entity.Property(e => e.Telefon).HasMaxLength(100);

                entity.Property(e => e.Vorname).HasMaxLength(100);
            });

            modelBuilder.Entity<Lieferant>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Ort).HasMaxLength(100);

                entity.Property(e => e.Plz).HasMaxLength(10);

                entity.Property(e => e.Strasse).HasMaxLength(100);

                entity.Property(e => e.Telefon).HasMaxLength(100);
            });

            modelBuilder.Entity<Rechnung>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Betrag).HasColumnType("money");

                entity.Property(e => e.Dateiname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Datum).HasColumnType("date");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
