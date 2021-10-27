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
    public class TagRepository : ITagRepository
    {
        private readonly SiteDbContext _context;
        private IUnitOfWork _unitOfWork;

        public TagRepository(SiteDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }
       
        public async Task<int> Create(Tag Tag)
        {
            var result = _context.Tags.Add(Tag);
            await _unitOfWork.CommitAsync();

            return result.Entity.Id;
        }

        public async Task<Tag> GetById(int id)
        {
            return await _context.Tags.FindAsync(id);
        }
        public async Task<IList<Tag>> GetAll()
        {
            try
            {
                return await _context.Tags.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<Result> Update(Tag Tag)
        {
            _context.Entry(Tag).State = EntityState.Modified;

            await _unitOfWork.CommitAsync();

            return new Result(true);
        }

        public async Task<Result> Delete(Tag Tag)
        {
            _context.Entry(Tag).State = EntityState.Deleted;
            
            await _unitOfWork.CommitAsync();

            return new Result(true);
        }
    }
}
