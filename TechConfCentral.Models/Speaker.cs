namespace TechConfCentral.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public string Biography { get; set; }
        public string? ProfileImage { get; set; }
        public bool IsFeatured { get; set; } = false;
        // N:1 Talk to Speaker
        public ICollection<Talk> Talks { get; set; } = new List<Talk>();
    }
}
