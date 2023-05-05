namespace FREIIA_API.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? FromCompany { get; set; }
        public Role Role { get; set; }
        public List<ExpertiseParticipant>? ExpertiseParticipants { get; set; }
        //public List<Expertise>? Expertises { get; set; }
        public ParticipantContactInfo? ContactInfo { get; set; }
        public List<Connection>? ConnectionsAsFirstParticipant { get; set; }
        public List<Connection>? ConnectionsAsSecondParticipant { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public Color BackgroundColor
        {
            get
            {
                return Role.Color;
            }
        }
    }
}