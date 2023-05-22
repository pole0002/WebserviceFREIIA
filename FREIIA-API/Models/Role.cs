namespace FREIIA_API.Models
{
    public class Role
    {
        public int Id { get; set; }
        public int ChartId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual Color? Color { get; set; }
        public int ColorId { get; set; }
    }
}