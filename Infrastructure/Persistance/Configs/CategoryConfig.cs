using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Configs
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Id).UseIdentityColumn();

            builder.HasIndex(c => c.Title).IsUnique();

            builder.Property(c => c.Title).HasMaxLength(150).IsRequired();
            
            builder.Property(c => c.Description).HasMaxLength(200).IsRequired();


            builder.HasIndex(c => c.EnTitle).IsUnique();
            builder.Property(c => c.EnTitle).HasMaxLength(150).IsRequired();

            builder.Property(c => c.EnDescription).HasMaxLength(200);

            builder.Property(c => c.Picture).HasMaxLength(200);
            builder.HasMany(c => c.Categories).WithOne(c => c.ParentCategory).HasForeignKey(c => c.ParentId);

            builder.Property(c => c.DateInsert).HasDefaultValue(DateTime.Now).IsRequired();
            
            builder.Property(c => c.TimeStamp).IsRowVersion();

        }
    }
}
