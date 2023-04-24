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
        public List<Zone>? Zones { get; set; } = new List<Zone>();
        public List<Group>? Groups { get; set; } = new List<Group>();
        public List<Participant>? Participants { get; set; } = new List<Participant>();
    }
}
