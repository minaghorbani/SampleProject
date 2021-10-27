using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
  public  interface ICategoryRepository
    {
        Task<int> Create(Category Category);
        Task<Category> GetById(int id);
        Task<IList<Category>> GetAll();
        Task<Result> Update(Category Category);
        Task<Result> Delete(Category Category);
    }
}
