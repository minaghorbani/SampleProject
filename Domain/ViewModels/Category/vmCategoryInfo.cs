using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Category
{
    public class vmCategoryInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string EnTitle { get; set; }
        public string EnDescription { get; set; }
        public string Picture { get; set; }
        public byte[] TimeStamp { get; set; }

    }
}
