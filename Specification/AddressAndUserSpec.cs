using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using appapi.Entity;

namespace appapi.Specification
{
    public class AddressAndUserSpec:Specification<AddressEntity>
    {
        public AddressAndUserSpec(int id):base(x => x.id == id)
        {
            AddInclude(x => x.user);
        }

        public AddressAndUserSpec()
        {
            AddInclude(x => x.user);
        }
    }
}