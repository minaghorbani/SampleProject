using Domain.Common;
using Domain.Entities;
using Infrastructure.Persistance;
using Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly SiteDbContext _context;
        private IUnitOfWork _unitOfWork;

        public BlogRepository(SiteDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }
       
        public async Task<int> Create(Blog blog)
        {
            var result = _context.Blogs.Add(blog);
            await _unitOfWork.CommitAsync();

            return result.Entity.Id;
        }

        public async Task<Blog> GetById(int id)
        {
            return await _context.Blogs.FindAsync(id);
        }
        public async Task<IList<Blog>> GetAll()
        {
            try
            {
                return await _context.Blogs.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<Result> Update(Blog blog)
        {
            _context.Entry(blog).State = EntityState.Modified;

            await _unitOfWork.CommitAsync();

            return new Result(true);
        }

        public async Task<Result> Delete(Blog blog)
        {
            _context.Entry(blog).State = EntityState.Deleted;
            
            await _unitOfWork.CommitAsync();

            return new Result(true);
        }
    }
}
