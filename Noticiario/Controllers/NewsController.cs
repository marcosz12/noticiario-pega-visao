using Microsoft.AspNetCore.Mvc;
using Noticiario.Models;
using Noticiario.Services;
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
            List<New> news = await _service.FindAllAsync();
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(New news)
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
            catch (IntegrityException ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }

            public IActionResult Error (string message) 
            {
                var viewModel = new ErrorViewModel
                {
                    Message = message
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                };
                return View(viewModel);
            }
        }
    }
}
