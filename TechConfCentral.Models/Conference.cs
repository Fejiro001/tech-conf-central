namespace TechConfCentral.Models
{
    public class Conference
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tagline { get; set; }
        public string? Description { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string Venue { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string Country { get; set; }
    }
}
