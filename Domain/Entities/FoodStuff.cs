using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FoodStuff
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string EnTitle { get; set; }
        public int Type { get; set; }

        public Collection<Post> Posts { get; set; }
        public Collection<PostFoodStuff> PostFoodStuffs { get; set; }

        public DateTime DateInsert { get; set; }
        public byte[] TimeStamp { get; set; }

        
    }
}
