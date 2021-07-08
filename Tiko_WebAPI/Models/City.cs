using System.ComponentModel.DataAnnotations;

namespace Tiko_WebAPI.Models
{
    public class City
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
    public class Agent
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public City City { get; set; }
    }
}