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
            return await _context.Speakers.ToListAsync();
        }
        // Get all featured speakers
        public async Task<List<Speaker>> GetFeaturedSpeakersAsync()
        {
            return await _context.Speakers
                .Where(s => s.IsFeatured)
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
                .FirstOrDefaultAsync(s => s.Id == id);
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
