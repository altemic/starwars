using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MvcCore.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsApiController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingsApiController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _ratingService.GetFilmRatings(id));
        }

        [HttpGet]
        public async Task<IActionResult> Average(string id)
        {
            return Ok(await _ratingService.GetAverageRating(id));
        }

        public async Task<IActionResult> Rate(Business.Dtos.FilmRatingDto rating)
        {
            return Ok(await _ratingService.Rate(rating));
        }
    }
}
