﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Tiko_Entities.Abstract;

namespace Tiko_Entities.Concrete
{
    [Table("Cities")]
    public class City : IEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
