namespace TechConfCentral.Models
{
    public class SavedTalk
    {
        public int Id { get; set; }
        public DateTime SavedAt { get; set; }
        // Foreign Keys
        public int TalkId { get; set; }
        public Talk Talk { get; set; }
        // TODO: Add User Identity key when ready
    }
}
