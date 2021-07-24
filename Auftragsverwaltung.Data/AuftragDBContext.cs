using System;
using Auftragsverwaltung.Data.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Auftragsverwaltung.Data
{
    public partial class AuftragDbContext : DbContext
    {
        public AuftragDbContext()
        {
        }

        public AuftragDbContext(DbContextOptions<AuftragDbContext> options)
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=192.168.1.34;database=AuftragDB;user id=sa;password=php5java2");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Artikel>(entity =>
            {
                entity.ToTable("Artikel");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PreisNetto).HasColumnType("money");

                entity.HasOne(d => d.Lieferant)
                    .WithMany(p => p.Artikel)
                    .HasForeignKey(d => d.LieferantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Artikel_Lieferant");
            });

            modelBuilder.Entity<Auftrag>(entity =>
            {
                entity.ToTable("Auftrag");

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
                entity.ToTable("AuftragsPositionen");

                entity.HasOne(d => d.Artikel)
                    .WithMany(p => p.AuftragsPositionen)
                    .HasForeignKey(d => d.ArtikelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuftragsPositionen_Artikel");

                entity.HasOne(d => d.Auftrag)
                    .WithMany(p => p.AuftragsPositionen)
                    .HasForeignKey(d => d.AuftragId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuftragsPositionen_Auftrag");
            });

            modelBuilder.Entity<Kunde>(entity =>
            {
                entity.ToTable("Kunde");

                entity.Property(e => e.Nachname).HasMaxLength(100);

                entity.Property(e => e.Ort).HasMaxLength(100);

                entity.Property(e => e.Plz).HasMaxLength(10);

                entity.Property(e => e.Strasse).HasMaxLength(100);

                entity.Property(e => e.Telefon).HasMaxLength(100);

                entity.Property(e => e.Vorname).HasMaxLength(100);
            });

            modelBuilder.Entity<Lieferant>(entity =>
            {
                entity.ToTable("Lieferant");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Ort).HasMaxLength(100);

                entity.Property(e => e.Plz).HasMaxLength(10);

                entity.Property(e => e.Strasse).HasMaxLength(100);

                entity.Property(e => e.Telefon).HasMaxLength(100);
            });

            modelBuilder.Entity<Rechnung>(entity =>
            {
                entity.ToTable("Rechnung");

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
