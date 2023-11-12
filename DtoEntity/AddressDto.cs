using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using appapi.Entity;

namespace appapi.DtoEntity
{
    public class AddressDto
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(150)]
        public string line_one { get; set; }
        public string line_second { get; set; }
        [Required]
        public string postcode { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        [Required]
        public string phone { get; set; }
        public string email { get; set; }
        public UserEntity user { get; set; }
    }
}