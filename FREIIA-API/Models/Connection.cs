using SQLitePCL;

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


        // Method for counting how many FK are left in connectionstable
        public static int CountForeignKeys(Connection connection)
        {
            int count = 0;

            if (connection.FirstZoneId != null)
            {
                count++;
            }
            if (connection.SecondZoneId != null)
            {
                count++;
            }
            if (connection.FirstGroupId != null)
            {
                count++;
            }
            if (connection.SecondGroupId != null)
            {
                count++;
            }
            if (connection.FirstParticipantId != null)
            {
                count++;
            }
            if (connection.SecondParticipantId != null)
            {
                count++;
            }

            return count;
        }
    }
}
