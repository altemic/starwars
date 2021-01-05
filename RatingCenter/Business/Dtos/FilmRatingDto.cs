using System;

namespace Business.Dtos
{
    public class FilmRatingDto
    {
        public string FilmRatingId { get; set; }
        
        public string ExternalId { get; set; }

        public int Rating { get; set; }

        public string Nickname { get; set; }

        public string Description { get; set; }
        
        public DateTime CreatedOn { get; set; }
    }
}
