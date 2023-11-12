using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace appapi.Specification
{
    public class Specification<T> : ISpecification<T> where T : class
    {
        public Specification(){}
        public Specification(Expression<Func<T, bool>> _criteria)
        {
            criteria = _criteria;
        }
        public Expression<Func<T, bool>> criteria {get;}

        public List<Expression<Func<T, object>>> include {get;} = new List<Expression<Func<T, object>>>();

        public void AddInclude(Expression<Func<T, object>>includeExpression)
        {
            include.Add(includeExpression);
        }
        
    }
}