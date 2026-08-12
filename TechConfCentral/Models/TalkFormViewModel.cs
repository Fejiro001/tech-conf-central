namespace TechConfCentral.Models
{
    public class TalkFormViewModel
    {
        public Talk Talk { get; set; } = new();
        public List<Conference> Conferences { get; set; } = [];
        public List<Track> Tracks { get; set; } = [];
        public List<Room> Rooms { get; set; } = [];
        public List<Speaker> Speakers { get; set; } = [];
    }
}
