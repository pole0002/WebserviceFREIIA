namespace FREIIA_API.Models
{
    public class Zone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
        public List<Group>? Groups { get; set; }
        public List<Participant>? Participants { get; set; }
        public List<Connection>? ConnectionsAsFirstZone { get; set; }
        public List<Connection>? ConnectionsAsSecondZone { get; set; }

        //private List<Connection> GetAllConnections()
        //{
        //    return ConnectionsAsFirstZone.AddRange(ConnectionsAsSecondZone);
        //}
    }
}