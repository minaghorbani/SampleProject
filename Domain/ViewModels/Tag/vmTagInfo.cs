using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels.Tag
{
    public class vmTagInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string EnTitle { get; set; }
        public string EnDescription { get; set; }
        public string Id_User { get; set; }
        public DateTime DateInsert { get; set; }
        public byte[] TimeStamp { get; set; }

    }
}
