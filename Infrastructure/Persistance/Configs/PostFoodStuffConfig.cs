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
    public class PostFoodStuffConfig : IEntityTypeConfiguration<PostFoodStuff>
    {
        public void Configure(EntityTypeBuilder<PostFoodStuff> builder)
        {
            builder.Property(c => c.Id).UseIdentityColumn();
            builder.HasKey(pt=> new { pt.PostId, pt.FoodStuffId});
            builder.HasOne(pt => pt.Post)
                .WithMany(pt => pt.PostFoodStuffs)
                .HasForeignKey(pt => pt.PostId);

            builder.HasOne(pt => pt.FoodStuff)
                .WithMany(pt => pt.PostFoodStuffs)
                .HasForeignKey(pt => pt.FoodStuffId);


            builder.Property(f => f.DateInsert).HasDefaultValue(DateTime.Now).IsRequired();

            builder.Property(f => f.TimeStamp).IsRowVersion();

        }
    }
}
