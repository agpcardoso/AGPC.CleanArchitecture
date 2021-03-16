using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AGPC.CleanArchitecture.Domain;
using AGPC.CleanArchitecture.Infra.EntityFrameworkConfig;
using AGPC.CleanArchitecture.Domain.Entities;

namespace AGPC.CleanArchitecture.Infra.EntityFwkConfig
{
    public class CustomerConfig : IEntityTypeConfiguration<CustomerEntity>, IEntityFwkConfig
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(x => x.Age).HasColumnType("int");
        }
    }
}
