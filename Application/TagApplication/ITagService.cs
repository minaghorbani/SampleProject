using Domain.Common;
using Domain.ViewModels.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TagApplication
{
    public interface ITagService
    {
        Task<Result> Create(vmTagInfo info);
        Task<vmTagInfo> FindById(int id);
        Task<Result> Update(vmTagInfo foodEditInfo);
        Task<Result> Remove(vmTagInfo foodEditInfo);
        Task<List<vmTagInfo>> GetAll();
        Task<List<vmTagInfo>> GetBySqlQuery();
    }
}
