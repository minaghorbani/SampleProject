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
    public class PostTagsConfig : IEntityTypeConfiguration<PostTags>
    {
        public void Configure(EntityTypeBuilder<PostTags> builder)
        {
            builder.HasKey(pt=> new { pt.PostId, pt.TagId});
            builder.HasOne(pt => pt.Post)
                .WithMany(pt => pt.PostTags)
                .HasForeignKey(pt => pt.PostId);

            builder.HasOne(pt => pt.Tag)
                .WithMany(pt => pt.PostTags)
                .HasForeignKey(pt => pt.TagId);


            builder.Property(f => f.DateInsert).HasDefaultValue(DateTime.Now).IsRequired();

            builder.Property(f => f.TimeStamp).IsRowVersion();

        }
    }
}
