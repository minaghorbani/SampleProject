using Domain.Common;
using Domain.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CategoryApplication
{
    public interface ICategoryService
    {
        Task<Result> Create(vmCategoryInfo info);
        Task<vmCategoryInfo> FindById(int id);
        Task<Result> Update(vmCategoryInfo foodEditInfo);
        Task<Result> Remove(vmCategoryInfo foodEditInfo);
        Task<List<vmCategoryInfo>> GetAll();
        Task<List<vmCategoryInfo>> GetBySqlQuery();
    }
}
