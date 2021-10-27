using Application.BlogApplication;
using Application.BlogApplication.Command.Create;
using Application.BlogApplication.Queries.FindById;
using Application.BlogApplication.Queries.GetAll;
using Domain.ViewModels.Blog;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebPresentation.Controllers
{
    //[ApiController]
    public class BlogController : Controller
    {
        private IWebHostEnvironment _Environment;
        private readonly IBlogService _blogService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BlogController(IBlogService blogService, IWebHostEnvironment environment, IWebHostEnvironment webHostEnvironment)
        {
            _blogService = blogService;
            _Environment = environment;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        [Route("/blog")]
        public IActionResult Get()
        {
            var entities = _blogService.GetAll();
            return Ok(entities.Result);
        }

        [HttpPost]
        [Route("/blog")]
        public IActionResult Post(vmBlogInfo model, IList<IFormFile> files)
        {
            var name = Guid.NewGuid().ToString();
            if (files != null && files.Count != 0)
            {

                var file = files[0];

                name += Path.GetExtension(file.FileName);
                var path = Path.Combine(
                               Directory.GetCurrentDirectory(),
                               "wwwroot\\Picture\\Blog", name);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                model.Picture = name.ToString();
            }

            var entities = _blogService.Create(model);

            return Ok(entities.Result);
        }

        [HttpPut]
        [Route("/blog")]
        public IActionResult Put(vmBlogInfo model)
        {
            var entities = _blogService.Update(model);

            return Ok(entities.Result);
        }

        [HttpDelete]
        [Route("/blog")]
        public IActionResult Delete(vmBlogInfo model)
        {
            var entities = _blogService.Remove(model);

            return Ok(entities.Result);
        }

        private string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);

            return filename;
        }

        private string GetPathAndFilename(string filename)
        {
            return this._Environment.WebRootPath + "\\uploads\\" + filename;
        }



        //private readonly IBlogService _blogService;

        //public BlogController(IBlogService blogService)
        //{
        //    _blogService = blogService;
        //}

        //public async Task<IActionResult> Create()
        //{

        //    vmBlogInfo model = new vmBlogInfo { Description = "22245", Title = "222" };
        //    var result = await _blogService.Create(model);
        //    return Ok(result);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Create(vmBlogInfo model)
        //{

        //    var result = await _blogService.Create(model);
        //    return Ok(result);
        //}


        //private readonly IMediator _mediator;
        //public BlogController(IMediator mediator)
        //{
        //    _mediator = mediator;
        //}

        //public async Task<IActionResult> Create(vmBlogInfo model)
        //{
        //    var en = new BlogCreateCommand()
        //    {
        //        Description = model.Description,
        //        Title = model.Title
        //    };
        //    var result = await _mediator.Send(en);

        //    return Ok(result);
        //}
        //public async Task<IActionResult> FindAll()
        //{
        //    var model = await _mediator.Send(new GetAllBlogsQuery());
        //    return Ok(model);
        //}
        //public async Task<IActionResult> FindById(int id)
        //{
        //    var model = await _mediator.Send(new FindBlogsByIdQuery() { Id = id });
        //    return Ok(model);
        //}
    }
}


//[HttpPost]
//public async Task<IActionResult> UploadFile(IFormFile file)
//{
//    if (file == null || file.Length == 0)
//        return Content("file not selected");

//    var path = Path.Combine(
//                Directory.GetCurrentDirectory(), "wwwroot",
//                file.GetFilename());

//    using (var stream = new FileStream(path, FileMode.Create))
//    {
//        await file.CopyToAsync(stream);
//    }

//    return RedirectToAction("Files");
//}

//public async Task<IActionResult> Download(string filename)
//{
//    if (filename == null)
//        return Content("filename not present");

//    var path = Path.Combine(
//                   Directory.GetCurrentDirectory(),
//                   "wwwroot", filename);

//    var memory = new MemoryStream();
//    using (var stream = new FileStream(path, FileMode.Open))
//    {
//        await stream.CopyToAsync(memory);
//    }
//    memory.Position = 0;
//    return File(memory, GetContentType(path), Path.GetFileName(path));
//}