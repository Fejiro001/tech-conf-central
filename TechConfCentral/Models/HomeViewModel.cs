namespace TechConfCentral.Models
{
    public class HomeViewModel
    {
        public List<Conference> Conferences { get; set; } = [];
        public int ConferenceCount { get; set; }
        public int SpeakerCount { get; set; }
        public int TalkCount { get; set; }
        public int TrackCount { get; set; }
    }
}
