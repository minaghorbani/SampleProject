using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PostTags
    {
        public int TagId { get; set; }
        public Tag Tag { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public DateTime DateInsert { get; set; }
        public byte[] TimeStamp { get; set; }
    }
}
