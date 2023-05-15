namespace FREIIA_API.Models
{
    public class Expertise
    {
        public int Id { get; set; }
        public int ChartId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Color Color { get; set; }
        //public List<Participant>? Participants { get; set; }
        public List<ExpertiseParticipant>? ExpertiseParticipants { get; set; }
    }
}