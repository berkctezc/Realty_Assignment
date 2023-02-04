namespace Tiko_Entities.Concrete;

[Dapper.Contrib.Extensions.Table("Cities")]
public class City : IEntity
{
    [Required]
    [Dapper.Contrib.Extensions.Key]
    public int Id { get; set; }

    [Required] public string Name { get; set; }
}