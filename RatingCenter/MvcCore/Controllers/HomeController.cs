using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcCore.Models;
using MvcCore.Services;

namespace MvcCore.Controllers
{
    public class FilmsController : Controller
    {
        private IFilmsService _filmsService;

        public FilmsController(IFilmsService filmsService)
        {
            _filmsService = filmsService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _filmsService.GetFilms());
        }

        public async Task<IActionResult> Details(string id)
        {
            var model = await _filmsService.GetFilmDetails(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RateFilm(FilmRatingViewModel model)
        {
            await this._filmsService.Rate(model);

            return RedirectToAction(nameof(Details), new { id = model.FilmId });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
