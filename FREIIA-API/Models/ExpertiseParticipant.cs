namespace FREIIA_API.Models
{
    public class ExpertiseParticipant
    {
        public int ExpertiseId { get; set; }
        public Expertise Expertise { get; set; }
        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }
        public bool IsMainExpertise { get; set; }
    }
}
