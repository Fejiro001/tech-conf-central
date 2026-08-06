namespace TechConfCentral.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        // N:1 Talk to Room
        public ICollection<Talk> Talks { get; set; } = new List<Talk>();
    }
}
