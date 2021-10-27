using AutoMapper;
using Domain.Common;
using Domain.Entities;
using Domain.ViewModels.Tag;
using Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TagApplication
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _TagRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<TagService> _logger;
        
        public TagService(ITagRepository TagRepository, IMapper mapper, ILogger<TagService> logger)
        {
            _TagRepository = TagRepository; 
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result> Create(vmTagInfo Tag)
        {
            var result = new Result(false);

            var model = _mapper.Map<vmTagInfo, Tag>(Tag);
            var id = await _TagRepository.Create(model);

            result.State = id == 0 ? false : true;

            _logger.LogInformation($"Tag {Tag.Id} has Inserted", Tag);

            return result;
        }

        public async Task<vmTagInfo> FindById(int id)
        {
            var model = await _TagRepository.GetById(id);
            return _mapper.Map<Tag, vmTagInfo>(model);
        }
        public async Task<Result> Update(vmTagInfo TagInfo)
        {
            var Tag = _mapper.Map<vmTagInfo, Tag>(TagInfo);
            return await _TagRepository.Update(Tag);

            _logger.LogInformation($"Tag {Tag.Id} has updated", Tag);
        }
        public Task<List<vmTagInfo>> GetBySqlQuery()
        {
            throw new NotImplementedException();
        }

        public async Task<List<vmTagInfo>> GetAll()
        {
            var model = await _TagRepository.GetAll();
            //model.Add(new Tag { Id = 10, Description = "ddddd", Title = "asdsd" });
            if (model.Count!=0)
            {
                var en = new List<vmTagInfo>();
                foreach (var item in model)
                {
                    en.Add(_mapper.Map<Tag, vmTagInfo>(item));
                }

                return en;
            }
            return null;
        }

        public async Task<Result> Remove(vmTagInfo TagInfo)
        {
            var Tag = _mapper.Map<vmTagInfo, Tag>(TagInfo);
            return await _TagRepository.Delete(Tag);

            _logger.LogInformation($"Tag {Tag.Id} has removed", Tag);
        }
    }
   
}
