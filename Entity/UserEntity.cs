using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace appapi.Entity
{
    public class UserEntity
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        
        [ForeignKey("address")]
        public int id_address { get; set; }

        public AddressEntity address { get; set; }
    }
}