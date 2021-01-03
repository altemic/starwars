using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Business.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcCore.Models
{
    public class FilmRatingViewModel
    {
        public string ExternalId { get; set; }

        [Display(Name = "Added")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Nickname")]
        public string Nickname { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Rating")]
        public int Rating { get; set; }

        public SelectList AllowedRatings => new SelectList(IRatingService.AllowedRatings());
    }
}
