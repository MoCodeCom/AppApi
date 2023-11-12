using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appapi.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace appapi.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(u => u.id).IsRequired();
            builder.HasOne(u => u.address).WithMany().HasForeignKey(u => u.id);
        }
    }
}