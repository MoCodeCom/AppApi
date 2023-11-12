using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appapi.Entity
{
    public class AddressEntity
    {
        public int id { get; set; }
        public string line_one { get; set; }
        public string line_second { get; set; }
        public string postcode { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public UserEntity user { get; set; }
    }
}