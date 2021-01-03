using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos;

namespace Business.Services
{
    public interface IFilmsService
    {
        Task<IEnumerable<FilmDto>> GetFilms();

        Task<FilmDto> GetFilmDetails(string id);
    }
}
