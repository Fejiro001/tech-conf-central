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
            return await _context.Tracks
                .AsNoTracking()
                .ToListAsync();
        }
        // Get all tracks that have talks by conference
        public async Task<List<Track>> GetTracksByConferenceAsync(int conferenceId)
        {
            return await _context.Tracks
                .Where(tr => tr.Talks.Any(t => t.ConferenceId == conferenceId))
                .AsNoTracking()
                .ToListAsync();
        }
        // Get track by id
        public async Task<Track?> GetTrackByIdAsync(int id)
        {
            return await _context.Tracks.FindAsync(id);
        }
        // Get the track count
        public async Task<int> GetTrackCountAsync()
        {
            return await _context.Tracks.CountAsync();
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
        // Check if a track name already exists
        public async Task<bool> TrackNameExistsAsync(string trackName, int trackId)
        {
            return await _context.Tracks
                .AnyAsync(t =>
                t.Name.ToLower() == trackName.ToLower() &&
                t.Id != trackId);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
