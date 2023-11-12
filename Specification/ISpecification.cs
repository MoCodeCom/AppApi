using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace appapi.Specification
{
    public interface ISpecification<T> where T:class
    {
        Expression<Func<T, bool>>criteria{get;}
        List<Expression<Func<T, object>>>include{get;}        
    }
}