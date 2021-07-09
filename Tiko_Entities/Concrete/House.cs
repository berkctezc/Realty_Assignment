﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tiko_Entities.Abstract;

namespace Tiko_Entities.Concrete
{
    [Table("Houses")]
    public class House : IEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public string Address { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(1, 10)]
        public int BedroomCount { get; set; }

        [Required]
        [ForeignKey("City")]
        public int CityId { get; set; }

        [Required]
        [ForeignKey("Agent")]
        public int AgentId { get; set; }
    }
}