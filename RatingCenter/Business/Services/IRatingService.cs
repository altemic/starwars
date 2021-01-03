using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos;

namespace Business.Services
{
    public interface IRatingService
    {
        Task<int> Rate(FilmRatingDto dto);

        Task<double> GetAverageRating(string id);

        //TODO: pagination
        Task<IEnumerable<FilmRatingDto>> GetFilmRatings(string id);

        static IEnumerable<int> AllowedRatings() => Enumerable.Range(0, 11);
    }
}
