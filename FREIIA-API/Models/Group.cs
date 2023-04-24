namespace FREIIA_API.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Participant>? Participants { get; set; } = new List<Participant>();
        public List<Connection>? ConnectionsAsFirstGroup { get; set; }
        public List<Connection>? ConnectionsAsSecondGroup { get; set; }
    }
}