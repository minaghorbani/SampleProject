using Application.TagApplication;
using Domain.ViewModels.Tag;
using Microsoft.AspNetCore.Mvc;

namespace WebPresentation.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _TagService;

        public TagController(ITagService TagService)
        {
            _TagService = TagService;
        }

        [HttpGet]
        [Route("/Tag")]
        public IActionResult Get()
        {
            var entities = _TagService.GetAll();
            return Ok(entities.Result);
        }

        [HttpPost]
        [Route("/Tag")]
        public IActionResult Post(vmTagInfo model)
        {
            var entities = _TagService.Create(model);

            return Ok(entities.Result);
        }

        [HttpPut]
        [Route("/Tag")]
        public IActionResult Put(vmTagInfo model)
        {
            var entities = _TagService.Update(model);

            return Ok(entities.Result);
        }

        [HttpDelete]
        [Route("/Tag")]
        public IActionResult Delete(vmTagInfo model)
        {
            var entities = _TagService.Remove(model);

            return Ok(entities.Result);
        }


        public IActionResult Index()
        {
            return View();
        }

    }
}

