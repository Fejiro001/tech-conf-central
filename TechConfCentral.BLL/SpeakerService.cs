using TechConfCentral.DAL;
using TechConfCentral.Models;

namespace TechConfCentral.BLL
{
    public class SpeakerService
    {
        private readonly SpeakerRepository _repository;
        public SpeakerService(SpeakerRepository repository)
        {
            _repository = repository;
        }
        // Get all speakers
        public async Task<List<Speaker>> GetSpeakersAsync()
        {
            return await _repository.GetSpeakersAsync();
        }
        // Get all featured speakers
        public async Task<List<Speaker>> GetFeaturedSpeakersAsync(int conferenceId)
        {
            return await _repository.GetFeaturedSpeakersAsync(conferenceId);
        }
        // Get all speakers for a conference
        public async Task<List<Speaker>> GetSpeakersByConferenceAsync(int conferenceId)
        {
            return await _repository.GetSpeakersByConferenceAsync(conferenceId);
        }
        // Get speaker by id
        public async Task<Speaker?> GetSpeakerByIdAsync(int id)
        {
            return await _repository.GetSpeakerByIdAsync(id);
        }
        // Get speaker by id with their talks
        public async Task<Speaker?> GetSpeakerWithTalksAsync(int id)
        {
            return await _repository.GetSpeakerWithTalksAsync(id);
        }
        // Get the speaker count
        public async Task<int> GetTaskCountAsync()
        {
            return await _repository.GetTaskCountAsync();
        }
        // Create speaker
        public async Task AddSpeakerAsync(Speaker speaker)
        {
            await _repository.AddSpeakerAsync(speaker);
            await _repository.SaveChangesAsync();
        }
        // Update speaker
        public async Task UpdateSpeakerAsync(Speaker speaker)
        {
            _repository.UpdateSpeaker(speaker);
            await _repository.SaveChangesAsync();
        }
        // Delete speaker
        public async Task DeleteSpeakerAsync(int id)
        {
            await _repository.DeleteSpeakerAsync(id);
            await _repository.SaveChangesAsync();
        }
    }
}
