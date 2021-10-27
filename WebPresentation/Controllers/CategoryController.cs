using Application.CategoryApplication;
using Domain.ViewModels.Category;
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
    public class CategoryController : Controller
    {
        private IWebHostEnvironment _Environment;
        private readonly ICategoryService _CategoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoryController(ICategoryService CategoryService, IWebHostEnvironment environment, IWebHostEnvironment webHostEnvironment)
        {
            _CategoryService = CategoryService;
            _Environment = environment;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        [Route("/Category")]
        public IActionResult Get()
        {
            var entities = _CategoryService.GetAll();
            return Ok(entities.Result);
        }

        [HttpPost]
        [Route("/Category")]
        public IActionResult Post(vmCategoryInfo model, IList<IFormFile> files)
        {
            var name = Guid.NewGuid().ToString();
            if (files != null && files.Count != 0)
            {

                var file = files[0];

                name += Path.GetExtension(file.FileName);
                var path = Path.Combine(
                               Directory.GetCurrentDirectory(),
                               "wwwroot\\Picture\\Category", name);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                model.Picture = name.ToString();
            }

            var entities = _CategoryService.Create(model);

            return Ok(entities.Result);
        }

        [HttpPut]
        [Route("/Category")]
        public IActionResult Put(vmCategoryInfo model)
        {
            var entities = _CategoryService.Update(model);

            return Ok(entities.Result);
        }

        [HttpDelete]
        [Route("/Category")]
        public IActionResult Delete(vmCategoryInfo model)
        {
            var entities = _CategoryService.Remove(model);

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

    }
}