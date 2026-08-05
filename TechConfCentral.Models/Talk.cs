namespace TechConfCentral.Models
{
    public class Talk
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public bool IsFeatured { get; set; } = false;
        public bool IsKeynote { get; set; } = false;
        // Foreign Keys
        public int ConferenceId { get; set; }
        public Conference Conference { get; set; }
        public int TrackId { get; set; }
        public Track Track { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int SpeakerId { get; set; }
        public Speaker Speaker { get; set; }
        public ICollection<SavedTalk> SavedTalks { get; set; } = new List<SavedTalk>();
    }
}
