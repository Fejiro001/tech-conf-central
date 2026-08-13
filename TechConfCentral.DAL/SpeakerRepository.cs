using Microsoft.EntityFrameworkCore;
using TechConfCentral.Models;

namespace TechConfCentral.DAL
{
    public class SpeakerRepository
    {
        private readonly TechConfCentralContext _context;
        public SpeakerRepository(TechConfCentralContext context)
        {
            _context = context;
        }
        // Get all speakers
        public async Task<List<Speaker>> GetSpeakersAsync()
        {
            return await _context.Speakers
                .AsNoTracking()
                .ToListAsync();
        }
        // Get all featured speakers
        public async Task<List<Speaker>> GetFeaturedSpeakersAsync(int conferenceId)
        {
            return await _context.Speakers
                .Where(s => s.IsFeatured)
                .Where(s => s.Talks.Any(t => t.ConferenceId == conferenceId))
                .Include(s => s.Talks)
                .AsNoTracking()
                .ToListAsync();
        }
        // Get all speakers for a conference
        public async Task<List<Speaker>> GetSpeakersByConferenceAsync(int conferenceId)
        {
            return await _context.Speakers
                .Where(s => s.Talks.Any(t => t.ConferenceId == conferenceId))
                .Include(s => s.Talks.Where(t => t.ConferenceId == conferenceId))
                .AsNoTracking()
                .ToListAsync();
        }
        // Get speaker by id
        public async Task<Speaker?> GetSpeakerByIdAsync(int id)
        {
            return await _context.Speakers.FindAsync(id);
        }
        // Get speaker by id with their talks
        public async Task<Speaker?> GetSpeakerWithTalksAsync(int id)
        {
            return await _context.Speakers
                .Include(s => s.Talks)
                .ThenInclude(t => t.Track)
                .Include(s => s.Talks)
                .ThenInclude(t => t.Room)
                .Include(s => s.Talks)
                .ThenInclude(t => t.Conference)
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);
        }
        // Get the speaker count
        public async Task<int> GetSpeakerCountAsync()
        {
            return await _context.Speakers.CountAsync();
        }
        // Create speaker
        public async Task AddSpeakerAsync(Speaker speaker)
        {
            await _context.Speakers.AddAsync(speaker);
        }
        // Update speaker
        public void UpdateSpeaker(Speaker speaker)
        {
            _context.Speakers.Update(speaker);
        }
        // Delete speaker
        public async Task DeleteSpeakerAsync(int id)
        {
            Speaker? speaker = await _context.Speakers.FindAsync(id);
            if (speaker != null)
            {
                _context.Speakers.Remove(speaker);
            }
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
