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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SiteDbContext _context;
        private IUnitOfWork _unitOfWork;

        public CategoryRepository(SiteDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }
       
        public async Task<int> Create(Category Category)
        {
            var result = _context.Categories.Add(Category);
            await _unitOfWork.CommitAsync();

            return result.Entity.Id;
        }

        public async Task<Category> GetById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }
        public async Task<IList<Category>> GetAll()
        {
            try
            {
                return await _context.Categories.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<Result> Update(Category Category)
        {
            _context.Entry(Category).State = EntityState.Modified;

            await _unitOfWork.CommitAsync();

            return new Result(true);
        }

        public async Task<Result> Delete(Category Category)
        {
            _context.Entry(Category).State = EntityState.Deleted;
            
            await _unitOfWork.CommitAsync();

            return new Result(true);
        }
    }
}
