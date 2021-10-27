using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PostFoodStuff
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }

        public int FoodStuffId { get; set; }
        public FoodStuff FoodStuff { get; set; }

        public DateTime DateInsert { get; set; }
        public byte[] TimeStamp { get; set; }
    }
}
