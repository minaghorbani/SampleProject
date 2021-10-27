using Domain.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Post:IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public byte[] Thumbnail { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }


        public DateTime DateInsert { get; set; }
        public byte[] TimeStamp { get; set; }
        public Collection<Tag> Tags { get; set; }
        public Collection<PostTags> PostTags { get; set; }

        public Collection<Category> Categories { get; set; }
        public Collection<PostCategory> PostCategories { get; set; }

        public Collection<FoodStuff> FoodStuffs { get; set; }
        public Collection<PostFoodStuff> PostFoodStuffs { get; set; }
    }
}
