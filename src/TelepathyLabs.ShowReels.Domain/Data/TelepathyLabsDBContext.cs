using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TelepathyLabs.ShowReels.Domain.Entity;

namespace TelepathyLabs.ShowReels.Domain.Data
{
    public class TelepathyLabsDbContext : DbContext
    {
        public TelepathyLabsDbContext(DbContextOptions<TelepathyLabsDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ShowReel> ShowReels { get; set; }
        public DbSet<VideoClip> VideoClips { get; set; }

        public DbSet<TimeCode> TimeCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TelepathyLabsDbContext).Assembly);

            modelBuilder.Entity<ShowReel>(entity =>
            {
                entity.HasKey(s => s.Id);

                entity.Property(s => s.Id)
                    .HasColumnName("Id")
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();

                entity.Property(s => s.Name)
                    .HasColumnName("Name")
                    .HasColumnType("varchar(100)")
                    .IsRequired();

                entity.Property(s => s.Description)
                    .HasColumnName("Description")
                    .HasColumnType("varchar(200)")
                    .IsRequired();

                entity.Property(s => s.VideoDefinition)
                    .HasColumnName("VideoDefinition")
                    .HasColumnType("smallint")
                    .IsRequired();

                entity.Property(s => s.VideoStandard)
                    .HasColumnName("VideoStandard")
                    .HasColumnType("smallint")
                    .IsRequired();

                entity.HasMany(s => s.VideoClips)
                    .WithOne();
            });

            modelBuilder.Entity<VideoClip>(entity =>
            {
                entity.HasKey(v => v.Id);

                entity.Property(v => v.Id)
                    .HasColumnName("Id")
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();

                entity.Property(v => v.Name)
                    .HasColumnName("Name")
                    .HasColumnType("varchar(100)")
                    .IsRequired();

                entity.Property(v => v.Description)
                    .HasColumnName("Description")
                    .HasColumnType("varchar(200)")
                    .IsRequired();

                entity.Property(v => v.VideoDefinition)
                    .HasColumnName("VideoDefinition")
                    .HasColumnType("smallint")
                    .IsRequired();

                entity.Property(v => v.VideoStandard)
                    .HasColumnName("VideoStandard")
                    .HasColumnType("smallint")
                    .IsRequired();

                entity.HasOne<TimeCode>(s => s.StartTimeCode)
                    .WithOne()
                    .HasForeignKey<TimeCode>(ad => ad.Id);

                entity.HasOne<TimeCode>(s => s.EndTimeCode)
                    .WithOne()
                    .HasForeignKey<TimeCode>(ad => ad.Id);
            });

            modelBuilder.Entity<TimeCode>(entity =>
            {
                entity.HasKey(v => v.Id);

                entity.Property(v => v.Id)
                    .HasColumnName("Id")
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();

                entity.Property(v => v.Hours)
                    .HasColumnName("Hours")
                    .HasColumnType("int").IsRequired();

                entity.Property(v => v.Minutes)
                    .HasColumnName("Minutes")
                    .HasColumnType("int").IsRequired();

                entity.Property(v => v.Seconds)
                    .HasColumnName("Seconds")
                    .HasColumnType("int").IsRequired();

                entity.Property(v => v.Frames)
                    .HasColumnName("Frames")
                    .HasColumnType("int").IsRequired();

                entity.Property(v => v.FramesPerSecond)
                    .HasColumnName("FramesPerSecond")
                    .HasColumnType("int");
            });
        }
    }
}
