using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos;
using Entities;
using Entities.Models;
using Integrations.StarWars;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    class FilmsService: IFilmsService
    {
        private readonly IStarWarsClient _client;

        private readonly FilmsContext _context;

        private readonly Mapper _mapper;

        public FilmsService(IStarWarsClient client)
        {
            _client = client;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Integrations.Dtos.FilmDto, Business.Dtos.FilmDto>();
            });

            _mapper = new Mapper(config);
        }

        //TODO: pagination
        public async Task<IEnumerable<Business.Dtos.FilmDto>> GetFilms()
        {
            var films = _mapper
                .Map<IEnumerable<Integrations.Dtos.FilmDto>, IEnumerable<Business.Dtos.FilmDto>>(
                    await _client.GetFilms());

            return films?.OrderBy(model => model.ExternalId);
        }

        public async Task<Business.Dtos.FilmDto> GetFilmDetails(string id) => 
            _mapper.Map<Integrations.Dtos.FilmDto, Business.Dtos.FilmDto>(await _client.GetFilmDetails(id));
    }
}
