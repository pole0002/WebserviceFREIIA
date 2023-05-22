namespace FREIIA_API.Models
{
    public class Zone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Color? Color { get; set; }
        public int ColorId { get; set; }
        public virtual List<Group>? Groups { get; set; }
        public virtual List<Participant>? Participants { get; set; }
        public virtual List<Connection>? ConnectionsAsFirstZone { get; set; }
        public virtual List<Connection>? ConnectionsAsSecondZone { get; set; }
    }
}