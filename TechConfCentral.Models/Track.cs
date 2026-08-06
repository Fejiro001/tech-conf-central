namespace TechConfCentral.Models
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        // N:1 Talk to Track
        public ICollection<Talk> Talks { get; set; } = new List<Talk>();
    }
}
