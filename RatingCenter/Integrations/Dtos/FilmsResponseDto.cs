using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Integrations.Dtos
{
    public class FilmsResponseDto
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("results")]
        public FilmDto[] Films { get; set; }
    }
}
