using Microsoft.EntityFrameworkCore;
using TechConfCentral.Models;

namespace TechConfCentral.DAL
{
    public class TechConfCentralContext : DbContext
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
        }
    }
}
