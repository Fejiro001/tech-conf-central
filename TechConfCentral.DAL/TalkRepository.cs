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

        // Talk Schedule with filtering
        public async Task<List<Talk>> GetScheduleAsync(int conferenceId, int? day, int? trackId, int? roomId)
        {
            var query = TalksWithDetails()
                .Where(t => t.ConferenceId == conferenceId);

            if (day.HasValue)
            {
                DateOnly conferenceStart = await _context.Conferences
                    .Where(c => c.Id == conferenceId)
                    .Select(c => c.StartDate)
                    .FirstAsync();

                DateOnly selectedDate = conferenceStart.AddDays(day.Value - 1);

                query = query.Where(t => DateOnly.FromDateTime(t.StartDateTime) == selectedDate);
            }

            if (trackId.HasValue)
            {
                query = query.Where(t => t.TrackId == trackId);
            }

            if (roomId.HasValue)
            {
                query = query.Where(t => t.RoomId == roomId); ;
            }

            return await query
                .OrderBy(t => t.StartDateTime)
                .AsNoTracking()
                .ToListAsync();
        }
        // Get Featured Talks
        public async Task<List<Talk>> GetFeaturedTalksAsync(int conferenceId)
        {
            return await TalksWithDetails()
                .Where(t => t.ConferenceId == conferenceId && t.IsFeatured)
                .AsNoTracking()
                .ToListAsync();
        }
        // Get Keynote Talk
        public async Task<Talk?> GetKeynoteTalkAsync(int conferenceId)
        {
            return await TalksWithDetails()
                .Where(t => t.ConferenceId == conferenceId && t.IsKeynote)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
        // Get Talks Associated with Speaker
        public async Task<List<Talk>> GetTalksBySpeakerAsync(int speakerId)
        {
            return await TalksWithDetails()
                .Where(t => t.SpeakerId == speakerId)
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
        public async Task<bool> IsRoomBookedAsync(int roomId, DateTime startTime, DateTime endTime, int? excludeTalkId = null)
        {
            return await _context.Talks
                .AnyAsync(t => t.RoomId == roomId &&
                                t.Id != excludeTalkId &&
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
