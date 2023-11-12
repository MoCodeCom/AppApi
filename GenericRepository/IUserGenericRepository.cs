using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using appapi.Specification;

namespace appapi.GenericRepository
{
    public interface IUserGenericRepository<T> where T:class
    {
        //Task<T>GetUserByIdAsync(Expression<Func<T,bool>>?filter = null, bool tracked=true);
        Task<T>GetUserByIdAsync(ISpecification<T>spec);
        //Task<IReadOnlyList<T>>GetAllUsersAsync(Expression<Func<T,bool>>?filter=null, bool tracked=true);
        Task<IReadOnlyList<T>>GetAllUsersAsync(ISpecification<T>spec);
        Task GreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task SaveAsync();
    }
}