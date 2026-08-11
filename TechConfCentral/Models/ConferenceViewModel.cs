namespace TechConfCentral.Models
{
    public class ConferenceViewModel
    {
        public Conference? Conference { get; set; } = null;
        public Talk? FeaturedKeynote { get; set; }
        public List<Track> Tracks { get; set; } = [];
        public List<Speaker> FeaturedSpeakers { get; set; } = [];
        public List<Talk> FeaturedTalks { get; set; } = [];
    }
}
