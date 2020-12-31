using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Integrations.Dtos
{
    public class FilmsDto
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("results")]
        public FilmDto[] Films { get; set; }
    }
}
