using Microsoft.EntityFrameworkCore;
using TechConfCentral.DAL;
using TechConfCentral.Models;

namespace TechConfCentral.BLL
{
    public class TrackService
    {
        private readonly TrackRepository _repository;
        public TrackService(TrackRepository repository)
        {
            _repository = repository;
        }
        // Get all tracks
        public async Task<List<Track>> GetTracksAsync()
        {
            return await _repository.GetTracksAsync();
        }
        // Get all tracks that have talks by conference
        public async Task<List<Track>> GetTracksByConferenceAsync(int conferenceId)
        {
            return await _repository.GetTracksByConferenceAsync(conferenceId);
        }
        // Get track by id
        public async Task<Track?> GetTrackByIdAsync(int id)
        {
            return await _repository.GetTrackByIdAsync(id);
        }
        // Get the track count
        public async Task<int> GetTrackCountAsync()
        {
            return await _repository.GetTrackCountAsync();
        }
        // Create track
        public async Task AddTrackAsync(Track track)
        {
            await ValidateTrackAsync(track);

            await _repository.AddTrackAsync(track);
            await _repository.SaveChangesAsync();
        }
        // Update track
        public async Task UpdateTrackAsync(Track track)
        {
            await ValidateTrackAsync(track);

            _repository.UpdateTrack(track);
            await _repository.SaveChangesAsync();
        }
        // Delete track
        public async Task DeleteTrackAsync(int id)
        {
            await _repository.DeleteTrackAsync(id);
            await _repository.SaveChangesAsync();
        }
        private async Task ValidateTrackAsync(Track track)
        {
            bool nameExists = await _repository.TrackNameExistsAsync(track.Name, track.Id);

            if (nameExists)
            {
                throw new ArgumentException($"A track with the name '{track.Name}' already exists.");
            }
        }
    }
}
