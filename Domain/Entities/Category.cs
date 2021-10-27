using Domain.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string EnTitle { get; set; }
        public string EnDescription { get; set; }
        public string Id_User { get; set; }
        public string Picture { get; set; }


        public int? ParentId { get; set; }
        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> Categories { get; set; }


        public Collection<Post> Posts { get; set; }
        public Collection<PostCategory> PostCategories { get; set; }
        public DateTime DateInsert { get; set; }
        public byte[] TimeStamp { get; set; }




    }
}
