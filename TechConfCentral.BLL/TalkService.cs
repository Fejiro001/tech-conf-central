using TechConfCentral.DAL;
using TechConfCentral.Models;

namespace TechConfCentral.BLL
{
    public class TalkService
    {
        private readonly TalkRepository _repository;
        private readonly ConferenceRepository _conferenceRepository;
        private readonly RoomRepository _roomRepository;
        private readonly SpeakerRepository _speakerRepository;
        private readonly TrackRepository _trackRepository;

        public TalkService(
            TalkRepository repository,
            ConferenceRepository conferenceRepository,
            RoomRepository roomRepository,
            SpeakerRepository speakerRepository,
            TrackRepository trackRepository)
        {
            _repository = repository;
            _conferenceRepository = conferenceRepository;
            _roomRepository = roomRepository;
            _speakerRepository = speakerRepository;
            _trackRepository = trackRepository;
        }
        // Get all talks
        public async Task<List<Talk>> GetTalksAsync()
        {
            return await _repository.GetTalksAsync();
        }
        // Get Talks for Schedule with additional filtering
        public async Task<List<Talk>> GetScheduleAsync(
            int conferenceId,
            int? day = null,
            int? trackId = null,
            int? roomId = null)
        {
            return await _repository.GetScheduleAsync(
                conferenceId,
                day,
                trackId,
                roomId);
        }
        // Get Featured Talks for Homepage
        public async Task<List<Talk>> GetFeaturedTalksAsync(int conferenceId)
        {
            return await _repository.GetFeaturedTalksAsync(conferenceId);
        }
        // Get Keynote Talk for Homepage
        public async Task<Talk?> GetKeynoteTalkAsync(int conferenceId)
        {
            return await _repository.GetKeynoteTalkAsync(conferenceId);
        }
        // Get Talks Associated with Speaker for Speaker page
        public async Task<List<Talk>> GetTalksBySpeakerAsync(int speakerId)
        {
            return await _repository.GetTalksBySpeakerAsync(speakerId);
        }
        // Get Talk by id
        public async Task<Talk?> GetTalkByIdAsync(int id)
        {
            return await _repository.GetTalkByIdAsync(id);
        }
        // Get the talk count
        public async Task<int> GetTalkCountAsync()
        {
            return await _repository.GetTalkCountAsync();
        }
        // Create Talk
        public async Task AddTalkAsync(Talk talk)
        {
            await ValidateTalkAsync(talk, null);

            await _repository.AddTalkAsync(talk);
            await _repository.SaveChangesAsync();
        }
        // Update Talk
        public async Task UpdateTalkAsync(Talk talk)
        {
            await ValidateTalkAsync(talk, talk.Id);

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

            if (await _roomRepository.GetRoomByIdAsync(talk.RoomId) == null)
            {
                throw new ArgumentException("Room does not exist.");
            }

            if (await _speakerRepository.GetSpeakerByIdAsync(talk.SpeakerId) == null)
            {
                throw new ArgumentException("Speaker does not exist.");
            }

            if (await _trackRepository.GetTrackByIdAsync(talk.TrackId) == null)
            {
                throw new ArgumentException("Track does not exist.");
            }

            if (talk.EndDateTime <= talk.StartDateTime)
            {
                throw new ArgumentException("End date must be after start date.");
            }

            DateOnly talkStartDate = DateOnly.FromDateTime(talk.StartDateTime);
            DateOnly talkEndDate = DateOnly.FromDateTime(talk.EndDateTime);

            // Ensures a talk start and end date are within a conference start and end date
            if (talkStartDate < conference.StartDate || talkEndDate > conference.EndDate)
            {
                throw new ArgumentException("Talk must occur within the conference dates.");
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
