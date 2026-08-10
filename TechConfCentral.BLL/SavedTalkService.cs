using TechConfCentral.DAL;
using TechConfCentral.Models;

namespace TechConfCentral.BLL
{
    public class SavedTalkService
    {
        private readonly SavedTalkRepository _repository;
        public SavedTalkService(SavedTalkRepository repository)
        {
            _repository = repository;
        }
        // Get all Saved Talks
        public async Task<List<SavedTalk>> GetSavedTalksForUserAsync(string userId)
        {
            return await _repository.GetSavedTalksForUserAsync(userId);
        }
        // Save a Talk
        public async Task SaveTalkAsync(SavedTalk savedtalk)
        {
            bool isTalkSaved = await _repository.IsTalkSavedAsync(savedtalk.UserId, savedtalk.TalkId);

            if (isTalkSaved)
            {
                throw new Exception("Talk has already been saved.");
            }
            await _repository.SaveTalkAsync(savedtalk);
            await _repository.SaveChangesAsync();
        }
        // Delete Saved Talk
        public async Task RemoveSavedTalkAsync(int id)
        {
            await _repository.RemoveSavedTalkAsync(id);
            await _repository.SaveChangesAsync();
        }
    }
}
