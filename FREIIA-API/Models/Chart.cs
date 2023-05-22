using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json.Serialization;

namespace FREIIA_API.Models
{
    public class Chart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual List<Zone>? Zones { get; set; } = new List<Zone>();
        public virtual List<Group>? Groups { get; set; } = new List<Group>();
        public virtual List<Participant>? Participants { get; set; } = new List<Participant>();
    }
}
