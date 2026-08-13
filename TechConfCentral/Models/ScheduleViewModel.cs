namespace TechConfCentral.Models
{
    public class ScheduleViewModel
    {
        public Conference? Conference { get; set; }
        // Filtered talks
        public List<Talk> Talks { get; set; } = [];
        public List<Track> Tracks { get; set; } = [];
        public List<Room> Rooms { get; set; } = [];
        public int? SelectedTrackId { get; set; }
        public int? SelectedRoomId { get; set; }
        public int? SelectedDay { get; set; } = 1;
        // Stores IDs of talks saved by the current user
        public HashSet<int> SavedTalkIds { get; set; } = [];
    }
}
