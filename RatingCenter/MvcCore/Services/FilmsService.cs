using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Entities.Models;
using Integrations.Dtos;
using Integrations.StarWars;
using Microsoft.EntityFrameworkCore;
using MvcCore.Models;

namespace MvcCore.Services
{
    //If rating functionality is to be used in other apps, should be extracted
    //Depending on complexity of the solution we can/should split dtos into many layers,
    //But for sake of simplicity I am using the same model as in view
    public class FilmsService: IFilmsService
    {
        private readonly IStarWarsClient _client;

        private readonly FilmsContext _context;

        private readonly Mapper _mapper;

        public FilmsService(
            IStarWarsClient client,
            FilmsContext context)
        {
            _client = client;
            _context = context;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Integrations.Dtos.FilmDto, MvcCore.Models.FilmViewModel>();
                cfg.CreateMap<Entities.Models.FilmRating, MvcCore.Models.FilmRatingViewModel>();
            });

            _mapper = new Mapper(config);
        }
        
        public async Task<IEnumerable<FilmViewModel>> GetFilms()
        {
            var films = await _client.GetFilms();

            var filmModels = films?.Select(dto => _mapper.Map<FilmDto, FilmViewModel>(dto));

            return filmModels?.OrderBy(model => model.Id);
        }

        public async Task<FilmViewModel> GetFilmDetails(string id)
        {
            var filmTask = _client.GetFilmDetails(id);

            //TODO: pagination
            var ratingsTask = _context.Set<FilmRating>()
                .Where(f => f.ExternalId == id)
                .Take(10)
                .ToListAsync();

            var averageRatingTask = GetAverageRating(id);

            var film = await filmTask;
            var ratings = await ratingsTask;
            var averageRating = await averageRatingTask;

            if (film == null)
                return null;

            var filmModel = _mapper.Map(film, new FilmViewModel
            {
                Ratings = ratings.Select(r => _mapper.Map(
                    r,
                    new FilmRatingViewModel { FilmId = film.Id })),
                AverageRating = averageRating
            });

            return filmModel;
        }

        public async Task<int> Rate(FilmRatingViewModel model)
        {
            ValidateRating(model.Rating);

            var entry = await _context.AddAsync(new FilmRating
            {
                ExternalId = model.FilmId,
                Rating = model.Rating,
                Nickname = model.Nickname,
                Description = model.Description
            });

            await _context.SaveChangesAsync();

            return entry.Entity.FilmRatingId;
        }

        public async Task<double> GetAverageRating(string id)
        {
            IQueryable<FilmRating> ratings = _context.Set<FilmRating>()
                .Where(e => e.ExternalId == id);

            if (ratings.Any())
                return await ratings.AverageAsync(e => e.Rating);

            return 0;
        }

        public IEnumerable<int> AllowedRatings() => Enumerable.Range(0, 11);

        private void ValidateRating(int rating)
        {
            if (!AllowedRatings().Contains(rating))
                throw new ArgumentOutOfRangeException($"Rating {rating} is outside of valid range.");
        }
    }
}
