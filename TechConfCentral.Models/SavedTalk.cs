namespace TechConfCentral.Models
{
    public class SavedTalk
    {
        public int Id { get; set; }
        public DateTime SavedAt { get; set; }
        // Foreign Keys
        public int TalkId { get; set; }
        public Talk Talk { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
