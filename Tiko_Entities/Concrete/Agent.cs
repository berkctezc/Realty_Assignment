using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tiko_Entities.Abstract;

namespace Tiko_Entities.Concrete
{
    [Table("Agents")]
    public class Agent : IEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey("City")]
        public int CityId { get; set; }
    }
}