using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using appapi.Entity;
using Microsoft.EntityFrameworkCore;

namespace appapi.Data
{
    public class DbContextApi:DbContext
    {
        public DbContextApi(DbContextOptions ops):base(ops)
        {
            
        }

        public DbSet<UserEntity>User { get; set; }
        public DbSet<AddressEntity>Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}