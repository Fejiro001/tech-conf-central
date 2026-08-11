using TechConfCentral.DAL;
using TechConfCentral.Models;

namespace TechConfCentral.BLL
{
    public class TalkService
    {
        private readonly TalkRepository _repository;
        private readonly ConferenceRepository _conferenceRepository;
        public TalkService(TalkRepository repository, ConferenceRepository conferenceRepository)
        {
            _repository = repository;
            _conferenceRepository = conferenceRepository;
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
        public async Task<List<Talk>> GetFeaturedTalksAsync(int conferenceId)
        {
            return await _repository.GetFeaturedTalksAsync(conferenceId);
        }
        // Get Keynote Talk
        public async Task<Talk?> GetKeynoteTalkAsync(int conferenceId)
        {
            return await _repository.GetKeynoteTalkAsync(conferenceId);
        }
        // Get Talks for Schedule
        public async Task<List<Talk>> GetTalksForScheduleAsync(int conferenceId)
        {
            return await _repository.GetTalksForScheduleAsync(conferenceId);
        }
        // Get Talk by id
        public async Task<Talk?> GetTalkByIdAsync(int id)
        {
            return await _repository.GetTalkByIdAsync(id);
        }

        // Create Talk
        public async Task AddTalkAsync(Talk talk)
        {
            await ValidateTalkAsync(talk, talk.Id);

            await _repository.AddTalkAsync(talk);
            await _repository.SaveChangesAsync();
        }
        // Update Talk
        public async Task UpdateTalkAsync(Talk talk)
        {
            await ValidateTalkAsync(talk, null);

            _repository.UpdateTalk(talk);
            await _repository.SaveChangesAsync();
        }
        // Delete Talk
        public async Task DeleteTalkAsync(int id)
        {
            await _repository.DeleteTalkAsync(id);
            await _repository.SaveChangesAsync();
        }
        private async Task ValidateTalkAsync(Talk talk, int? excludeTalkId)
        {
            Conference? conference = await _conferenceRepository.GetConferenceByIdAsync(talk.ConferenceId) ?? throw new ArgumentException("Conference does not exist.");

            DateOnly talkStartDate = DateOnly.FromDateTime(talk.StartDateTime);
            DateOnly talkEndDate = DateOnly.FromDateTime(talk.EndDateTime);

            // Ensures a talk start and end date are within a conference start and end date
            if (talkStartDate < conference.StartDate || talkEndDate > conference.EndDate)
            {
                throw new ArgumentException("Talk must occur within the conference dates.");
            }

            if (talk.EndDateTime <= talk.StartDateTime)
            {
                throw new ArgumentException("End date must be after start date.");
            }

            // Checks if a room is available
            bool isRoomBooked = await _repository.IsRoomBookedAsync(
                talk.RoomId,
                talk.StartDateTime,
                talk.EndDateTime,
                excludeTalkId);

            if (isRoomBooked)
            {
                throw new InvalidOperationException("The selected room is already booked during this time frame.");
            }
        }
    }
}
