using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using appapi.Entity;

namespace appapi.DtoEntity
{
    public class UserDto
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
        public string first_name { get; set; }
        [MaxLength(50)]
        public string last_name { get; set; }
        public AddressEntity address{get; set;}
    }
}