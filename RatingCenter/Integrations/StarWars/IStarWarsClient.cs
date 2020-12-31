using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Integrations.Dtos;

namespace Integrations.StarWars
{
    public interface IStarWarsClient
    {
        Task<IEnumerable<FilmDto>> GetFilms();

        Task<FilmDto> GetFilmDetails(string id);
    }
}
