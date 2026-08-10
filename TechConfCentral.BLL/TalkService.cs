using TechConfCentral.DAL;
using TechConfCentral.Models;

namespace TechConfCentral.BLL
{
    public class TalkService
    {
        private readonly TalkRepository _repository;
        public TalkService(TalkRepository repository)
        {
            _repository = repository;
        }
        // Get Talks By Conference
        public async Task<List<Talk>> GetTalksByConferenceAsync(int conferenceId)
        {
            return await _repository.GetTalksByConferenceAsync(conferenceId);
        }
        // Get Talks By Track
        public async Task<List<Talk>> GetTalksByTrackAsync(int trackId)
        {
            return await _repository.GetTalksByTrackAsync(trackId);
        }
        // Get Talks Associated with Speaker
        public async Task<List<Talk>> GetTalksBySpeakerAsync(int speakerId)
        {
            return await _repository.GetTalksBySpeakerAsync(speakerId);
        }
        // Get Talks by Room
        public async Task<List<Talk>> GetTalksByRoomAsync(int roomId)
        {
            return await _repository.GetTalksByRoomAsync(roomId);
        }
        // Get Featured Talks
        public async Task<List<Talk>> GetFeaturedTalksAsync()
        {
            return await _repository.GetFeaturedTalksAsync();
        }
        // Get Keynote Talk
        public async Task<Talk?> GetKeynoteTalkAsync()
        {
            return await _repository.GetKeynoteTalkAsync();
        }
        // Get Talks for Schedule
        public async Task<List<Talk>> GetTalksForScheduleAsync()
        {
            return await _repository.GetTalksForScheduleAsync();
        }
        // Get Talk by id
        public async Task<Talk?> GetTalkByIdAsync(int id)
        {
            return await _repository.GetTalkByIdAsync(id);
        }

        // Create Talk
        public async Task AddTalkAsync(Talk talk)
        {
            var roomTalks = await GetTalksByRoomAsync(talk.RoomId);

            if (talk.EndDateTime < talk.StartDateTime)
            {
                throw new ArgumentException("End date must be after start date.");
            }

            bool isRoomBooked = await _repository.IsRoomBookedAsync(
                talk.RoomId,
                talk.StartDateTime,
                talk.EndDateTime);

            if (isRoomBooked)
            {
                throw new InvalidOperationException("The selected room is already booked during this time frame.");
            }
            await _repository.AddTalkAsync(talk);
            await _repository.SaveChangesAsync();
        }
        // Update Talk
        public async Task UpdateTalk(Talk talk)
        {
            _repository.UpdateTalk(talk);
            await _repository.SaveChangesAsync();
        }
        // Delete Talk
        public async Task DeleteTalkAsync(int id)
        {
            await _repository.DeleteTalkAsync(id);
            await _repository.SaveChangesAsync();
        }
    }
}
