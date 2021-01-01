using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcCore.Models;

namespace MvcCore.Services
{
    public interface IFilmsService
    {
        Task<IEnumerable<FilmViewModel>> GetFilms();

        Task<FilmViewModel> GetFilmDetails(string id);

        Task<int> Rate(FilmRatingViewModel model);

        Task<double> GetAverageRating(string id);

        static IEnumerable<int> AllowedRatings() => Enumerable.Range(0,11);
    }
}
