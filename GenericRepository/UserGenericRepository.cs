using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using appapi.Data;
using appapi.Specification;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace appapi.GenericRepository
{
    public class UserGenericRepository<T> : IUserGenericRepository<T> where T : class
    {
        private readonly DbContextApi _context;
        internal DbSet<T> dbSet;

        public UserGenericRepository(DbContextApi context)
        {
            _context = context; 
            this.dbSet = _context.Set<T>();
        }
        
        //public async Task<IReadOnlyList<T>> GetAllUsersAsync(Expression<Func<T, bool>>? filter = null, bool tracked=true)
        public async Task<IReadOnlyList<T>> GetAllUsersAsync(ISpecification<T>spec)
        {
            /*
            IQueryable<T>qurey = dbSet;
            if(filter != null)
            {
                qurey = qurey.Where(filter);
            }*/
            //return await _context.Set<T>().ToListAsync();
            //return await qurey.ToListAsync();
            return await ApplySpecification(spec).ToListAsync();
        }

        //public async Task<T> GetUserByIdAsync(Expression<Func<T, bool>>? filter = null, bool tracked=true)
        public async Task<T> GetUserByIdAsync(ISpecification<T>spec)
        {
            /*
            IQueryable<T>qurey = dbSet;
            if(!tracked)
            {
                qurey = qurey.AsNoTracking();
            }

            if(filter != null)
            {
                qurey = qurey.Where(filter);
            }*/
            //return await _context.Set<T>().FirstAsync();
            return await ApplySpecification(spec).FirstOrDefaultAsync();

            //return await qurey.FirstOrDefaultAsync();
        }

        public async Task GreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await SaveAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Update(entity);
            await SaveAsync();
            return entity;
        }

        protected IQueryable<T>ApplySpecification(ISpecification<T>spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        } 
    }
}