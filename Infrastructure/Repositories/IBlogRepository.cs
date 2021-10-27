﻿using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
  public  interface IBlogRepository
    {
        Task<int> Create(Blog blog);
        Task<Blog> GetById(int id);
        Task<IList<Blog>> GetAll();
        Task<Result> Update(Blog blog);
        Task<Result> Delete(Blog blog);
    }
}
