namespace Tiko_Entities.DTOs;

public class HouseDetail : IDto
{
    public int Id { get; set; }
    public int Price { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public int BedroomCount { get; set; }
    public string CityName { get; set; }
    public string AgentName { get; set; }
}