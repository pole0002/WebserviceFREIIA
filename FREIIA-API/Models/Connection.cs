namespace FREIIA_API.Models
{
    public class Connection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ConnectionStyle ConnectionStyle { get; set; }

        public int? FirstZoneId { get; set; }
        public Zone? FirstZone { get; set; }
        public int? SecondZoneId { get; set; }
        public Zone? SecondZone { get; set; }

        public int? FirstGroupId { get; set; }
        public Group? FirstGroup { get; set; }
        public int? SecondGroupId { get; set; }
        public Group? SecondGroup { get; set; }

        public int? FirstParticipantId { get; set; }
        public Participant? FirstParticipant { get; set; }
        public int? SecondParticipantId { get; set; }
        public Participant? SecondParticipant { get; set; }
    }
}