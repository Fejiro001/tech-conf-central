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
        // Get all conference
        public async Task<List<Conference>> GetConferencesAsync()
        {
            return await _context.Conferences.ToListAsync();
        }
        // Get conference by id
        public async Task<Conference> GetConferenceByIdAsync(int id)
        {
            return await _context.Conferences.FindAsync(id);
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
