using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASPORM.scaffoldedDBO
{
    public partial class apiContext : DbContext
    {
        public apiContext()
        {
        }

        public apiContext(DbContextOptions<apiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; } = null!;
        public virtual DbSet<T1> T1s { get; set; } = null!;
        public virtual DbSet<Test> Tests { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("name=ConnectionStrings:myLocalDB", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.9.3-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("armscii8_bin")
                .HasCharSet("armscii8");

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<T1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("t1");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.T11)
                    .HasColumnType("int(11)")
                    .HasColumnName("t1");

                entity.Property(e => e.T2)
                    .HasColumnType("int(11)")
                    .HasColumnName("t2");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("test");

                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .HasColumnName("id");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
