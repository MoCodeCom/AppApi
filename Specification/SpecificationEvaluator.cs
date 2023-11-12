using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace appapi.Specification
{
    public class SpecificationEvaluator<T> where T:class
    {
        public static IQueryable<T>GetQuery(
            IQueryable<T>inputQurey,
            ISpecification<T>sepc
        )
        {
            var qurey = inputQurey;
            if(sepc.criteria != null)
            {
                qurey  = qurey.Where(sepc.criteria);
            }
            qurey = sepc.include.Aggregate(qurey, (current, include)=> current.Include(include));
            return qurey;
        }
    }
}