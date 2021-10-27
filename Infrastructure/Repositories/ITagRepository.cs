using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
  public  interface ITagRepository
    {
        Task<int> Create(Tag blog);
        Task<Tag> GetById(int id);
        Task<IList<Tag>> GetAll();
        Task<Result> Update(Tag blog);
        Task<Result> Delete(Tag blog);
    }
}
