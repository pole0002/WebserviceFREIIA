namespace FREIIA_API.Models
{
    public class Expertise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Participant>? Participants { get; set; }
    }
}