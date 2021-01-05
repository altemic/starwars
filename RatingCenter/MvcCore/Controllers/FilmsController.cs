using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace MvcCore.Controllers
{
    public class FilmsController : Controller
    {
        private readonly IFilmsService _filmsService;
        private readonly IRatingService _ratingService;
        private readonly Mapper _mapper;

        public FilmsController(IFilmsService filmsService, IRatingService ratingService)
        {
            _filmsService = filmsService;
            _ratingService = ratingService;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Business.Dtos.FilmDto, MvcCore.Models.FilmViewModel>();
                var ratingMap = cfg.CreateMap<Business.Dtos.FilmRatingDto, MvcCore.Models.FilmRatingViewModel>();
                ratingMap.ReverseMap();
            });

            _mapper = new Mapper(config);
        }

        public async Task<IActionResult> Index()
        {
            var filmDtos = await _filmsService.GetFilms();
            var filmModels =
                _mapper.Map<IEnumerable<Business.Dtos.FilmDto>, IEnumerable<MvcCore.Models.FilmViewModel>>(
                    filmDtos);

            return View(filmModels);
        }

        public async Task<IActionResult> Details(string ExternalId)
        {
            var filmTask = _filmsService.GetFilmDetails(ExternalId);
            var averageRatingTask = _ratingService.GetAverageRating(ExternalId);
            var filmRatingsTask = _ratingService.GetFilmRatings(ExternalId);
            
            var filmModel = _mapper.Map<Business.Dtos.FilmDto, MvcCore.Models.FilmViewModel>(await filmTask);

            //TODO: pagination
            filmModel.Ratings =
                _mapper.Map<IEnumerable<Business.Dtos.FilmRatingDto>, IEnumerable<MvcCore.Models.FilmRatingViewModel>>(
                    await filmRatingsTask);
            
            filmModel.AverageRating = await averageRatingTask;

            return View(filmModel);
        }

        public async Task<IActionResult> RateFilm(MvcCore.Models.FilmRatingViewModel model)
        {
            var ratingDto = _mapper.Map<MvcCore.Models.FilmRatingViewModel, Business.Dtos.FilmRatingDto>(model);
            
            await this._ratingService.Rate(ratingDto);

            return RedirectToAction(nameof(Details), new {ExternalId = model.ExternalId});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new MvcCore.Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
