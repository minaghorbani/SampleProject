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
    public class PostCategoryConfig : IEntityTypeConfiguration<PostCategory>
    {
        public void Configure(EntityTypeBuilder<PostCategory> builder)
        {
            builder.HasKey(pt=> new { pt.PostId, pt.CategoryId});
            builder.HasOne(pt => pt.Post)
                .WithMany(pt => pt.PostCategories)
                .HasForeignKey(pt => pt.PostId);

            builder.HasOne(pt => pt.Category)
                .WithMany(pt => pt.PostCategories)
                .HasForeignKey(pt => pt.CategoryId);


            builder.Property(f => f.DateInsert).HasDefaultValue(DateTime.Now).IsRequired();

            builder.Property(f => f.TimeStamp).IsRowVersion();

        }
    }
}
