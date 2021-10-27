using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PostCategory
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public DateTime DateInsert { get; set; }
        public byte[] TimeStamp { get; set; }
    }
}
