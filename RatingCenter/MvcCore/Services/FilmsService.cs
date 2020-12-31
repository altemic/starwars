using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcCore.Models;

namespace MvcCore.Services
{
    public class FilmsService: IFilmsService
    {
        public Task<IEnumerable<FilmViewModel>> GetFilms()
        {
            throw new NotImplementedException();
        }

        public Task<FilmViewModel> GetFilmDetails(string id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Rate(FilmRatingViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<double> GetAverageRating(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> AllowedRatings()
        {
            throw new NotImplementedException();
        }
    }
}
