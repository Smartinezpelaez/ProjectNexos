using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Nexos.DAL.Models
{
    public partial class NexosContext : DbContext
    {
        public NexosContext()
        {
        }

        public NexosContext(DbContextOptions<NexosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Bookss> Booksses { get; set; } = null!;
        public virtual DbSet<Record> Records { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-I0OTQSJ\\SQLEXPRESS;Database=Nexos;User ID=ProjectNexos;Password=Sqa123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.IdAuthor);

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Bookss>(entity =>
            {
                entity.HasKey(e => e.IdBook);

                entity.ToTable("Bookss");

                entity.Property(e => e.IdBook).ValueGeneratedOnAdd();

                entity.Property(e => e.Author)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Year).HasColumnType("date");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithOne(p => p.Bookss)
                    .HasForeignKey<Bookss>(d => d.IdBook)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bookss_Authors");
            });

            modelBuilder.Entity<Record>(entity =>
            {
                entity.HasKey(e => e.IdRecord);

                entity.HasOne(d => d.IdAuthorNavigation)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.IdAuthor)
                    .HasConstraintName("FK_Records_Authors");

                entity.HasOne(d => d.IdBookNavigation)
                    .WithMany(p => p.Records)
                    .HasForeignKey(d => d.IdBook)
                    .HasConstraintName("FK_Records_Bookss");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
