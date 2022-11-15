using System;
using System.Collections.Generic;
using iBot.Models.IbotDevelopment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace iBot.Models
{
    public partial class IbotDevelopmentContext : DbContext
    {
        public IbotDevelopmentContext()
        {
        }

        public IbotDevelopmentContext(DbContextOptions<IbotDevelopmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActiveRanLoad> ActiveRanLoads { get; set; } = null!;
        public virtual DbSet<AdmActiveDocumentsDefault> AdmActiveDocumentsDefaults { get; set; } = null!;

        public virtual DbSet<X500> X500s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("dbconn");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActiveRanLoad>(entity =>
            {
                entity.HasKey(e => e.Projectcode);

                entity.ToTable("active_Ran_Load");

                entity.Property(e => e.Active).HasMaxLength(255);

                entity.Property(e => e.Customer).HasMaxLength(255);

                entity.Property(e => e.Fund).HasMaxLength(255);

                entity.Property(e => e.Projectcode)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Ran)
                    .HasMaxLength(255)
                    .HasColumnName("RAN #");

                entity.Property(e => e.TechPoc)
                    .HasMaxLength(255)
                    .HasColumnName("Tech POC");

                entity.Property(e => e.WbsElement)
                    .HasMaxLength(255)
                    .HasColumnName("WBS Element");
            });

            modelBuilder.Entity<AdmActiveDocumentsDefault>(entity =>
            {
                entity.HasKey(e => e.DocumentNum);

                entity.ToTable("AdmActiveDocumentsDefault");

                entity.Property(e => e.DocumentNum)
                    .HasMaxLength(24)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Vendor)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });



            modelBuilder.Entity<X500>(entity =>
            {
                entity.HasKey(e => e.UniqueId);

                entity.ToTable("X500");

                entity.HasIndex(e => e.Uupic, "IX_X500_UUPIC");

                entity.HasIndex(e => e.UniqueId, "IX_X500_UniqueID");

                entity.Property(e => e.AgencyId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("AgencyID");

                entity.Property(e => e.Building)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Center)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Employer)
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.EmployerAbbr)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MailCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Mi)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MI")
                    .IsFixedLength();

                entity.Property(e => e.Org)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Room)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UniqueId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("UniqueID");

                entity.Property(e => e.Uupic)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("UUPIC");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
