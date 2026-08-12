using Microsoft.EntityFrameworkCore;
using TechConfCentral.Models;

namespace TechConfCentral.DAL
{
    public class ConferenceRepository
    {
        private readonly TechConfCentralContext _context;
        public ConferenceRepository(TechConfCentralContext context)
        {
            _context = context;
        }
        // Get all conferences
        public async Task<List<Conference>> GetConferencesAsync()
        {
            return await _context.Conferences
                .Include(c => c.Talks)
                .AsNoTracking()
                .ToListAsync();
        }
        // Get conference by id
        public async Task<Conference?> GetConferenceByIdAsync(int id)
        {
            return await _context.Conferences.FindAsync(id);
        }
        // Get conference by id with its Talks
        public async Task<Conference?> GetConferenceWithTalksAsync(int id)
        {
            return await _context.Conferences
                .Include(c => c.Talks)
                .ThenInclude(t => t.Speaker)
                .Include(c => c.Talks)
                .ThenInclude(t => t.Track)
                .Include(c => c.Talks)
                .ThenInclude(t => t.Room)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        // Get the conference count
        public async Task<int> GetConferenceCountAsync()
        {
            return await _context.Conferences.CountAsync();
        }
        // Create conference
        public async Task AddConferenceAsync(Conference conference)
        {
            await _context.Conferences.AddAsync(conference);
        }
        // Update conference
        public void UpdateConference(Conference conference)
        {
            _context.Conferences.Update(conference);
        }
        // Delete conference
        public async Task DeleteConferenceAsync(int id)
        {
            Conference? conference = await _context.Conferences.FindAsync(id);
            if (conference != null)
            {
                _context.Conferences.Remove(conference);
            }
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
