using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TechConfCentral.Models;

namespace TechConfCentral.DAL
{
    public class TechConfCentralContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Talk> Talks { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<SavedTalk> SavedTalks { get; set; }
        public TechConfCentralContext(DbContextOptions<TechConfCentralContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // --- Primary Keys ---
            modelBuilder.Entity<Conference>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Track>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<Speaker>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<Talk>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<Room>()
                .HasKey(r => r.Id);
            modelBuilder.Entity<SavedTalk>()
                .HasKey(st => st.Id);

            // --- Properties ---
            modelBuilder.Entity<Conference>(entity =>
            {
                // Not use EF's default pluralization
                entity.ToTable("Conference");

                entity.Property(c => c.Name).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Tagline).IsRequired().HasMaxLength(255);
                entity.Property(c => c.Description).HasMaxLength(255);

                entity.Property(c => c.StartDate).IsRequired();
                entity.Property(c => c.EndDate).IsRequired();

                entity.Property(c => c.Venue).IsRequired().HasMaxLength(255);
                entity.Property(c => c.City).IsRequired().HasMaxLength(125);
                entity.Property(c => c.StateOrProvince).IsRequired().HasMaxLength(100);
                entity.Property(c => c.Country).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.ToTable("Track");

                entity.Property(tr => tr.Name).IsRequired().HasMaxLength(100);
                entity.Property(tr => tr.Description).HasMaxLength(255);
                entity.Property(tr => tr.Color).HasMaxLength(7);
            });

            modelBuilder.Entity<Speaker>(entity =>
            {
                entity.ToTable("Speaker");

                entity.Property(s => s.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(s => s.LastName).IsRequired().HasMaxLength(100);
                entity.Property(s => s.JobTitle).IsRequired().HasMaxLength(255);
                entity.Property(s => s.Company).IsRequired().HasMaxLength(100);

                entity.Property(s => s.Biography).IsRequired();
                entity.Property(s => s.ProfileImage).HasMaxLength(255);
                entity.Property(s => s.IsFeatured).IsRequired().HasDefaultValue(false);
            });

            modelBuilder.Entity<Talk>(entity =>
            {
                entity.ToTable("Talk");

                entity.Property(t => t.Title).IsRequired().HasMaxLength(255);
                entity.Property(t => t.Description).IsRequired();

                entity.Property(t => t.StartDateTime).IsRequired();
                entity.Property(t => t.EndDateTime).IsRequired();

                entity.Property(t => t.IsFeatured).IsRequired().HasDefaultValue(false);
                entity.Property(t => t.IsKeynote).IsRequired().HasDefaultValue(false);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(r => r.Name).IsRequired().HasMaxLength(100);
                entity.Property(r => r.Capacity).IsRequired();
            });

            modelBuilder.Entity<SavedTalk>(entity =>
            {
                entity.ToTable("SavedTalk");

                entity.Property(st => st.SavedAt).IsRequired();
            });

            // --- Relationships ---
            // 1:N Conference to Talk
            modelBuilder.Entity<Conference>()
                .HasMany(c => c.Talks)
                .WithOne(t => t.Conference)
                .HasForeignKey(t => t.ConferenceId)
                .OnDelete(DeleteBehavior.Restrict);
            // 1:N Track to Talk
            modelBuilder.Entity<Track>()
                .HasMany(tr => tr.Talks)
                .WithOne(t => t.Track)
                .HasForeignKey(t => t.TrackId)
                .OnDelete(DeleteBehavior.Restrict);
            // 1:N Room to Talk
            modelBuilder.Entity<Room>()
                .HasMany(r => r.Talks)
                .WithOne(t => t.Room)
                .HasForeignKey(t => t.RoomId)
                .OnDelete(DeleteBehavior.Restrict);
            // 1:N Speaker to Talk
            modelBuilder.Entity<Speaker>()
                .HasMany(s => s.Talks)
                .WithOne(t => t.Speaker)
                .HasForeignKey(t => t.SpeakerId)
                .OnDelete(DeleteBehavior.Restrict);

            // --- N:N ApplicationUser to Talk ---
            modelBuilder.Entity<SavedTalk>(entity =>
            {
                // 1:N User to SavedTalk
                entity.HasOne(st => st.User)
                    .WithMany(u => u.SavedTalks)
                    .HasForeignKey(st => st.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                // 1:N Talk to SavedTalk
                entity.HasOne(st => st.Talk)
                    .WithMany(t => t.SavedTalks)
                    .HasForeignKey(st => st.TalkId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Unique Constraint: Prevent duplicate saves for same user and talk
                entity.HasIndex(st => new { st.UserId, st.TalkId })
                    .IsUnique();
            });
        }
    }
}
