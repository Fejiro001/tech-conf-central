using Microsoft.EntityFrameworkCore;
using TechConfCentral.Models;

namespace TechConfCentral.DAL
{
    public class SavedTalkRepository
    {
        private readonly TechConfCentralContext _context;
        public SavedTalkRepository(TechConfCentralContext context)
        {
            _context = context;
        }
        // Get all Saved Talks
        // User Id is a string because of AspnetUsers
        public async Task<List<SavedTalk>> GetSavedTalksForUserAsync(string userId)
        {
            return await _context.SavedTalks
                .Where(st => st.UserId == userId)
                .Include(st => st.Talk)
                .AsNoTracking()
                .ToListAsync();
        }
        // Save a Talk
        public async Task SaveTalkAsync(SavedTalk savedtalk)
        {
            await _context.SavedTalks.AddAsync(savedtalk);
        }
        // Delete Saved Talk
        public async Task RemoveSavedTalkAsync(string userId, int talkId)
        {
            SavedTalk? savedtalk = await _context.SavedTalks.FirstOrDefaultAsync(st => st.UserId == userId && st.TalkId == talkId);

            if (savedtalk != null)
            {
                _context.SavedTalks.Remove(savedtalk);
            }
        }
        // Check if a Talk is saved
        public async Task<bool> IsTalkSavedAsync(string userId, int talkId)
        {
            return await _context.SavedTalks
                .AnyAsync(st => st.UserId == userId &&
                                st.TalkId == talkId);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
