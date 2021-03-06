﻿using System.Threading.Tasks;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace MvcCore.Controllers.Api
{
    [Route("api/films")]
    [ApiController]
    public class FilmsApiController : ControllerBase
    {
        private readonly IFilmsService _filmsService;

        public FilmsApiController(IFilmsService filmsService)
        {
            _filmsService = filmsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _filmsService.GetFilms());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _filmsService.GetFilmDetails(id));
        }
    }
}
