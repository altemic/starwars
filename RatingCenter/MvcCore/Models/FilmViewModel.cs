using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.Models
{
    public class FilmViewModel
    {
        [Display(Name = "#")]
        public string Id { get; set; }

        [Display(Name = "Episode ID")]
        public int EpisodeId { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Opening Crawl")]
        public string OpeningCrawl { get; set; }

        [Display(Name = "Director")]
        public string Director { get; set; }

        [Display(Name = "Producer")]
        public string Producer { get; set; }

        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime ReleaseDate { get; set; }

        private double _averageRating;
        [Display(Name = "Average Rating")]
        public double AverageRating
        {
            get => Math.Round(_averageRating, 2);
            set => _averageRating = value;
        }

        public FilmRatingViewModel Rating => new FilmRatingViewModel { ExternalId = Id };

        public IEnumerable<FilmRatingViewModel> Ratings { get; set; }
    }
}
