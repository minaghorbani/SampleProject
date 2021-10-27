using Application.BlogApplication.Command.Create;
using AutoMapper;
using Domain.Entities;
using Domain.ViewModels.Blog;
using Domain.ViewModels.Category;
using Domain.ViewModels.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
   public class Mappers: Profile
    {
        public Mappers()
        {
            CreateMap<vmBlogInfo, Blog>();
            CreateMap<Blog, vmBlogInfo>();
            CreateMap<BlogCreateCommand, Blog>();
            //CreateMap<Blog, vmBlogInfo>().ReverseMap();

            CreateMap<vmTagInfo, Tag>();
            CreateMap<Tag, vmTagInfo>();

            CreateMap<vmCategoryInfo, Tag>();
            CreateMap<Tag, vmCategoryInfo>();

        }
    }
}
