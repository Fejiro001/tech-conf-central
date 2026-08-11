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
        public async Task SaveTalkAsync(string userId, int talkId)
        {
            bool isTalkSaved = await _repository.IsTalkSavedAsync(userId, talkId);

            if (isTalkSaved)
            {
                throw new InvalidOperationException("The talk has already been saved.");
            }
            SavedTalk savedTalk = new SavedTalk
            {
                UserId = userId,
                TalkId = talkId
            };

            await _repository.SaveTalkAsync(savedTalk);
            await _repository.SaveChangesAsync();
        }
        // Delete Saved Talk
        public async Task RemoveSavedTalkAsync(string userId, int talkId)
        {
            await _repository.RemoveSavedTalkAsync(userId, talkId);
            await _repository.SaveChangesAsync();
        }
    }
}
