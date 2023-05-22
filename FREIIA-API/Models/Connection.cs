namespace FREIIA_API.Models
{
    public class Connection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ConnectionStyle ConnectionStyle { get; set; }
        
        public int? FirstZoneId { get; set; }
        public virtual Zone? FirstZone { get; set; }
        public int? SecondZoneId { get; set; }
        public virtual Zone? SecondZone { get; set; }

        public int? FirstGroupId { get; set; }
        public virtual Group? FirstGroup { get; set; }
        public int? SecondGroupId { get; set; }
        public virtual Group? SecondGroup { get; set; }

        public int? FirstParticipantId { get; set; }
        public virtual Participant? FirstParticipant { get; set; }
        public int? SecondParticipantId { get; set; }
        public virtual Participant? SecondParticipant { get; set; }
    }
}