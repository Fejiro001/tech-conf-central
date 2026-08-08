using TechConfCentral.DAL;
using TechConfCentral.Models;

namespace TechConfCentral.BLL
{
    public class ConferenceService
    {
        private readonly ConferenceRepository _repository;
        public ConferenceService(ConferenceRepository repository)
        {
            _repository = repository;
        }
        // Get all conferences
        public async Task<List<Conference>> GetConferencesAsync()
        {
            return await _repository.GetConferencesAsync();
        }
        // Get conference by id
        public async Task<Conference?> GetConferenceByIdAsync(int id)
        {
            return await _repository.GetConferenceByIdAsync(id);
        }
        // Get conference by id with its Talks
        public async Task<Conference?> GetConferenceWithTalksAsync(int id)
        {
            return await _repository.GetConferenceWithTalksAsync(id);
        }
        // Create conference
        public async Task AddConferenceAsync(Conference conference)
        {
            if (conference.StartDate >= conference.EndDate)
            {
                throw new ArgumentException("End date must be after start date.");
            }

            await _repository.AddConferenceAsync(conference);
            await _repository.SaveChangesAsync();
        }
        // Update conference
        public async Task UpdateConferenceAsync(Conference conference)
        {
            if (conference.StartDate >= conference.EndDate)
            {
                throw new ArgumentException("End date must be after start date.");
            }

            _repository.UpdateConference(conference);
            await _repository.SaveChangesAsync();
        }
        // Delete conference
        public async Task DeleteConferenceAsync(int id)
        {
            await _repository.DeleteConferenceAsync(id);
            await _repository.SaveChangesAsync();
        }
    }
}
