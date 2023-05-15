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
        public Role Role { get; set; }
        public List<ExpertiseParticipant>? ExpertiseParticipants { get; set; }
        public ParticipantContactInfo? ContactInfo { get; set; }
        public List<Connection>? ConnectionsAsFirstParticipant { get; set; }
        public List<Connection>? ConnectionsAsSecondParticipant { get; set; }
    }
}