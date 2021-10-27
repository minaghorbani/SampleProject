using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.ViewModels.Blog;
using Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BlogApplication
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BlogService> _logger;

        public BlogService(IBlogRepository blogRepository, IMapper mapper, ILogger<BlogService> logger)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result> Create(vmBlogInfo blog)
        {
            var result = new Result(false);

            var model = _mapper.Map<vmBlogInfo, Blog>(blog);
            var id = await _blogRepository.Create(model);

            result.State = id == 0 ? false : true;

            _logger.LogInformation($"blog {blog.Id} has Inserted", blog);

            return result;
        }

        public async Task<vmBlogInfo> FindById(int id)
        {
            var model = await _blogRepository.GetById(id);
            return _mapper.Map<Blog, vmBlogInfo>(model);
        }
        public async Task<Result> Update(vmBlogInfo blogInfo)
        {
            var blog = _mapper.Map<vmBlogInfo, Blog>(blogInfo);
            return await _blogRepository.Update(blog);

            _logger.LogInformation($"blog {blog.Id} has updated", blog);
        }
        public Task<List<vmBlogInfo>> GetBySqlQuery()
        {
            throw new NotImplementedException();
        }

        public async Task<List<vmBlogInfo>> GetAll()
        {
            var model = await _blogRepository.GetAll();
            //model.Add(new Blog { Id = 10, Description = "ddddd", Title = "asdsd" });
            if (model.Count != 0)
            {
                var en = new List<vmBlogInfo>();
                foreach (var item in model)
                {
                    en.Add(_mapper.Map<Blog, vmBlogInfo>(item));
                }

                return en;
            }
            return null;
        }

        public async Task<Result> Remove(vmBlogInfo blogInfo)
        {
            var blog = _mapper.Map<vmBlogInfo, Blog>(blogInfo);
            return await _blogRepository.Delete(blog);

            _logger.LogInformation($"blog {blog.Id} has removed", blog);
        }
    }

}
