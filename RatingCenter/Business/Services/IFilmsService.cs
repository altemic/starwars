using System.Collections.Generic;
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
