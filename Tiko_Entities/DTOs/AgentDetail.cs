using Tiko_Entities.Abstract;

namespace Tiko_Entities.DTOs
{
    public class AgentDetail : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }
    }
}