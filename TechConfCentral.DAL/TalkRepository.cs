using Microsoft.EntityFrameworkCore;
using TechConfCentral.Models;

namespace TechConfCentral.DAL
{
    public class TalkRepository
    {
        private readonly TechConfCentralContext _context;
        public TalkRepository(TechConfCentralContext context)
        {
            _context = context;
        }
        // Get Talks By Conference
        public async Task<List<Talk>> GetTalksByConferenceAsync(int conferenceId)
        {
            return await TalksWithDetails()
                .Where(t => t.ConferenceId == conferenceId)
                .AsNoTracking()
                .ToListAsync();
        }
        // Get Talks By Track
        public async Task<List<Talk>> GetTalksByTrackAsync(int trackId)
        {
            return await TalksWithDetails()
                .Where(t => t.TrackId == trackId)
                .AsNoTracking()
                .ToListAsync();
        }
        // Get Talks Associated with Speaker
        public async Task<List<Talk>> GetTalksBySpeakerAsync(int speakerId)
        {
            return await TalksWithDetails()
                .Where(t => t.SpeakerId == speakerId)
                .AsNoTracking()
                .ToListAsync();
        }
        // Get Talks by Room
        public async Task<List<Talk>> GetTalksByRoomAsync(int roomId)
        {
            return await TalksWithDetails()
                .Where(t => t.RoomId == roomId)
                .AsNoTracking()
                .ToListAsync();
        }
        // Get Featured Talks
        public async Task<List<Talk>> GetFeaturedTalksAsync()
        {
            return await TalksWithDetails()
                .Where(t => t.IsFeatured)
                .AsNoTracking()
                .ToListAsync();
        }
        // Get Keynote Talk
        public async Task<Talk?> GetKeynoteTalkAsync()
        {
            return await TalksWithDetails()
                .Where(t => t.IsKeynote)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
        // Get Talks for Schedule
        public async Task<List<Talk>> GetTalksForScheduleAsync()
        {
            return await TalksWithDetails()
                .OrderBy(t => t.StartDateTime)
                .AsNoTracking()
                .ToListAsync();
        }
        // Get Talk by id
        public async Task<Talk?> GetTalkByIdAsync(int id)
        {
            return await TalksWithDetails()
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        // Create Talk
        public async Task AddTalkAsync(Talk talk)
        {
            await _context.Talks.AddAsync(talk);
        }
        // Update Talk
        public void UpdateTalk(Talk talk)
        {
            _context.Talks.Update(talk);
        }
        // Delete Talk
        public async Task DeleteTalkAsync(int id)
        {
            Talk? talk = await _context.Talks.FindAsync(id);
            if (talk != null)
            {
                _context.Talks.Remove(talk);
            }
        }
        // Check if a room is already booked during specific time frame
        public async Task<bool> IsRoomBookedAsync(int roomId, DateTime startTime, DateTime endTime)
        {
            return await _context.Talks
                .AnyAsync(t => t.RoomId == roomId &&
                                startTime < t.EndDateTime &&
                                endTime > t.StartDateTime);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        private IQueryable<Talk> TalksWithDetails()
        {
            return _context.Talks
                .Include(t => t.Conference)
                .Include(t => t.Track)
                .Include(t => t.Room)
                .Include(t => t.Speaker);
        }
    }
}
