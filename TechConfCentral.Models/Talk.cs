namespace TechConfCentral.Models
{
    public class Talk
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public bool IsFeatured { get; set; } = false;
        public bool IsKeynote { get; set; } = false;
        // 1:N Conference to Talk
        public int ConferenceId { get; set; }
        public Conference? Conference { get; set; }
        // 1:N Track to Talk
        public int TrackId { get; set; }
        public Track? Track { get; set; }
        // 1:N Room to Talk
        public int RoomId { get; set; }
        public Room? Room { get; set; }
        // 1:N Speaker to Talk
        public int SpeakerId { get; set; }
        public Speaker? Speaker { get; set; }
        // N:N ApplicationUser to Talk
        public ICollection<SavedTalk> SavedTalks { get; set; } = new List<SavedTalk>();
    }
}
