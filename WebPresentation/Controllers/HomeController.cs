using Application.OrderApplication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebPresentation.Models;

namespace WebPresentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrderService _OrderService;

        public HomeController(ILogger<HomeController> logger, IOrderService orderService)
        {
            _logger = logger;
            _OrderService = orderService;
        }

        public IActionResult Index()
        {
            var en=_OrderService.GetAll();
            return Ok(en.Result);
            return View();
        }
        public IActionResult Post()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize]
        public IActionResult testToken()
        {
            return Ok("approved mina");
        }
    }
}
