using Microsoft.AspNetCore.Mvc;
using Noticiario.Models;
using Noticiario.Models.ViewModels;
using Noticiario.Services;
using Noticiario.Services.Exceptions;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Noticiario.Controllers
{
    public class NewsController : Controller
    {
        private readonly NewService _service;
        public NewsController(NewService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<NewsItem> news = await _service.FindAllAsync();
            return View(news);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewsItem news)
        {
            
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _service.InsertAsync(news);
            return RedirectToAction(nameof(Index));
        }
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            var obj = await _service.FindByIdAsync(id.Value);
            if (obj is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityExceptions ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }

        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _service.FindByIdAsync(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NewsItem news)
        {
            if (id != news.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id's não condizentes" });
            }

            if (!ModelState.IsValid)
            {
                return View(news);
            }

            try
            {
                await _service.UpdateAsync(news);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            var obj = await _service.FindByIdAsync(id.Value);
            if (obj is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);

        }


        public IActionResult Error (string message) 
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
