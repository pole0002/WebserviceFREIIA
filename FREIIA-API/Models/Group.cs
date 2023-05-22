namespace FREIIA_API.Models
{
    public class Group
    {
        public int Id { get; set; }
        public int ChartId { get; set; }
        public int? ZoneId { get; set; }
        public string Name { get; set; }
        public virtual Color? Color { get; set; }
        public int ColorId { get; set; }
        public bool IsTopLevel { get; set; }
        public virtual List<Participant>? Participants { get; set; } = new List<Participant>();
        public virtual List<Connection>? ConnectionsAsFirstGroup { get; set; }
        public virtual List<Connection>? ConnectionsAsSecondGroup { get; set; }
    }
}