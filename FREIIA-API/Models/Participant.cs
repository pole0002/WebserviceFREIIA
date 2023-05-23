namespace FREIIA_API.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public int ChartId { get; set; }
        public int? GroupId { get; set; }
        public int? ZoneId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? FromCompany { get; set; }
        public bool IsTopLevel { get; set; }
        public virtual Role? Role { get; set; }
        public int? RoleId { get; set; }
        public virtual List<ExpertiseParticipant>? ExpertiseParticipants { get; set; }
        public virtual ParticipantContactInfo? ContactInfo { get; set; }
        public virtual List<Connection>? ConnectionsAsFirstParticipant { get; set; }
        public virtual List<Connection>? ConnectionsAsSecondParticipant { get; set; }
    }
}