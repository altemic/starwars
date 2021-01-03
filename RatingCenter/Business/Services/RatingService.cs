using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    class RatingService: IRatingService
    {
        private readonly FilmsContext _context;
        private Mapper _mapper;
        
        public RatingService(FilmsContext context)
        {
            _context = context;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Entities.Models.FilmRating, Business.Dtos.FilmRatingDto>();
            });

            _mapper = new Mapper(config);
        }

        public async Task<int> Rate(Business.Dtos.FilmRatingDto model)
        {
            ValidateRating(model.Rating);

            var entry = await _context.AddAsync(new Entities.Models.FilmRating
            {
                ExternalId = model.ExternalId,
                Rating = model.Rating,
                Nickname = model.Nickname,
                Description = model.Description
            });

            await _context.SaveChangesAsync();

            return entry.Entity.FilmRatingId;
        }

        public async Task<double> GetAverageRating(string id)
        {
            IQueryable<Entities.Models.FilmRating> ratings = _context.Set<Entities.Models.FilmRating>()
                .Where(e => e.ExternalId == id);

            if (ratings.Any())
                return await ratings.AverageAsync(e => e.Rating);

            return 0;
        }

        //TODO: pagination
        public async Task<IEnumerable<Business.Dtos.FilmRatingDto>> GetFilmRatings(string id)
        {
            var ratings = await _context.Set<Entities.Models.FilmRating>()
                .Where(f => f.ExternalId == id)
                .OrderByDescending(f => f.CreatedOn)
                .Take(10)
                .ToListAsync();

            return _mapper.Map<
                IEnumerable<Entities.Models.FilmRating>, 
                IEnumerable<Business.Dtos.FilmRatingDto>>(ratings);
        }

        private void ValidateRating(int rating)
        {
            if (!IRatingService.AllowedRatings().Contains(rating))
                throw new ArgumentOutOfRangeException($"Rating {rating} is outside of valid range.");
        }
    }
}
