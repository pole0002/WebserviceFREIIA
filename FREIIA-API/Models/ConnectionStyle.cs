namespace FREIIA_API.Models
{
    public class ConnectionStyle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Color Color { get; set; }
        public virtual LineStyle LineStyle { get; set; }
    }
}