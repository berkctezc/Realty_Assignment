namespace Tiko_Entities.Concrete;

[Dapper.Contrib.Extensions.Table("Agents")]
public class Agent : IEntity
{
    [Required]
    [Dapper.Contrib.Extensions.Key]
    public int Id { get; set; }

    [Required] public string Name { get; set; }

    [Required] [ForeignKey("City")] public int CityId { get; set; }
}