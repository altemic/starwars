using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Common.Exceptions;
using Integrations.Dtos;

namespace Integrations.StarWars
{
    public class StarWarsClient: IStarWarsClient
    {
        private HttpClient _httpClient;

        //IDK why setting this field in HttpClient throws error in .NET Core when sending request
        //TODO: move to configuration
        private const string _baseAddress = "https://swapi.dev/api/films/";

        public StarWarsClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        private async Task<T> Get<T>(Uri uri) where T : class
        {
            var response = await _httpClient.GetAsync(uri);

            if (response.StatusCode == HttpStatusCode.NoContent 
                || response.StatusCode == HttpStatusCode.NotFound)
                return null;

            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new ClientException(
                    $"Server responded with: {response.StatusCode} code, reason: {response.ReasonPhrase}");
            }

            var stream = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<T>(stream);

            return data;
        }

        //In production app, pagination should be added
        //In response from API all film details are also returned, so they could be cached here and used as already fetched
        //But here I decided to sent another request and do not store data about films in local db
        //Other possible implementation is to fetch data about films from API at start and store them in local db
        public async Task<IEnumerable<FilmDto>> GetFilms() =>
            (await Get<FilmsResponseDto>(new Uri(_baseAddress)))?.Films;

        public async Task<FilmDto> GetFilmDetails(string id) =>
            await Get<FilmDto>(new Uri($"{_baseAddress}{id}/"));
    }
}
