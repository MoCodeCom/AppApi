using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appapi.Entity;

namespace appapi.Specification
{
    public class UserAndAddressSpec:Specification<UserEntity>
    {
        public UserAndAddressSpec()
        {
            AddInclude(x => x.address);
        } 

        public UserAndAddressSpec(int id):base(x => x.id == id)
        {
            AddInclude(x => x.address);
        }  
    }
}