using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.ViewModels.Category;
using Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CategoryApplication
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _CategoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryService> _logger;
        
        public CategoryService(ICategoryRepository CategoryRepository, IMapper mapper, ILogger<CategoryService> logger)
        {
            _CategoryRepository = CategoryRepository; 
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result> Create(vmCategoryInfo Category)
        {
            var result = new Result(false);

            var model = _mapper.Map<vmCategoryInfo, Category>(Category);
            var id = await _CategoryRepository.Create(model);

            result.State = id == 0 ? false : true;

            _logger.LogInformation($"Category {Category.Id} has Inserted", Category);

            return result;
        }

        public async Task<vmCategoryInfo> FindById(int id)
        {
            var model = await _CategoryRepository.GetById(id);
            return _mapper.Map<Category, vmCategoryInfo>(model);
        }
        public async Task<Result> Update(vmCategoryInfo CategoryInfo)
        {
            var Category = _mapper.Map<vmCategoryInfo, Category>(CategoryInfo);
            return await _CategoryRepository.Update(Category);

            _logger.LogInformation($"Category {Category.Id} has updated", Category);
        }
        public Task<List<vmCategoryInfo>> GetBySqlQuery()
        {
            throw new NotImplementedException();
        }

        public async Task<List<vmCategoryInfo>> GetAll()
        {
            var model = await _CategoryRepository.GetAll();
            //model.Add(new Category { Id = 10, Description = "ddddd", Title = "asdsd" });
            if (model.Count!=0)
            {
                var en = new List<vmCategoryInfo>();
                foreach (var item in model)
                {
                    en.Add(_mapper.Map<Category, vmCategoryInfo>(item));
                }

                return en;
            }
            return null;
        }

        public async Task<Result> Remove(vmCategoryInfo CategoryInfo)
        {
            var Category = _mapper.Map<vmCategoryInfo, Category>(CategoryInfo);
            return await _CategoryRepository.Delete(Category);

            _logger.LogInformation($"Category {Category.Id} has removed", Category);
        }
    }
   
}
