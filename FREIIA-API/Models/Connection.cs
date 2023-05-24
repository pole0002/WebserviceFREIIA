using SQLitePCL;

namespace FREIIA_API.Models
{
    public class Connection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ConnectionStyle? ConnectionStyle { get; set; }
        public int ConnectionStyleId { get; set; }
        
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


        // Method for counting how many FK are left in connectionstable
        public int GetCountForeignKeys()
        {
            int count = 0;

            if (FirstZoneId != null)
            {
                count++;
            }
            if (SecondZoneId != null)
            {
                count++;
            }
            if (FirstGroupId != null)
            {
                count++;
            }
            if (SecondGroupId != null)
            {
                count++;
            }
            if (FirstParticipantId != null)
            {
                count++;
            }
            if (SecondParticipantId != null)
            {
                count++;
            }

            return count;
        }
    }
}
