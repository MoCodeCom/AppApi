using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appapi.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace appapi.Config
{
    public class AddressConfiguration : IEntityTypeConfiguration<AddressEntity>
    {
        public void Configure(EntityTypeBuilder<AddressEntity> builder)
        {
            builder.Property(u => u.id).IsRequired();
        }
    }
}