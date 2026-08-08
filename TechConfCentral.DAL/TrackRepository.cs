using Microsoft.EntityFrameworkCore;
using TechConfCentral.Models;

namespace TechConfCentral.DAL
{
    public class TrackRepository
    {
        private readonly TechConfCentralContext _context;
        public TrackRepository(TechConfCentralContext context)
        {
            _context = context;
        }
        // Get all tracks
        public async Task<List<Track>> GetTracksAsync()
        {
            return await _context.Tracks.ToListAsync();
        }
        // Get track by id
        public async Task<Track?> GetTrackByIdAsync(int id)
        {
            return await _context.Tracks.FindAsync(id);
        }
        // Create track
        public async Task AddTrackAsync(Track track)
        {
            await _context.Tracks.AddAsync(track);
        }
        // Update track
        public void UpdateTrack(Track track)
        {
            _context.Tracks.Update(track);
        }
        // Delete track
        public async Task DeleteTrackAsync(int id)
        {
            Track? track = await _context.Tracks.FindAsync(id);
            if (track != null)
            {
                _context.Tracks.Remove(track);
            }
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
