namespace FREIIA_API.Models
{
    public class ExpertiseParticipant
    {
        public virtual Expertise Expertise { get; set; }
        public int ExpertiseId { get; set; }
        public virtual Participant Participant { get; set; }
        public int ParticipantId { get; set; }
        public bool IsMainExpertise { get; set; }
    }
}