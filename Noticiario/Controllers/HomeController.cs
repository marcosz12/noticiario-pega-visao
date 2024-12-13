using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Noticiario.Data;
using Noticiario.Models;
using Noticiario.Models.ViewModels;
using Noticiario.Services;
using System.Diagnostics;


namespace Noticiario.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly NewService _service;

        public HomeController(ILogger<HomeController> logger, NewService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<NewsItem> news = await _service.FindAllAsync();
            return View(news);
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
    }
}
