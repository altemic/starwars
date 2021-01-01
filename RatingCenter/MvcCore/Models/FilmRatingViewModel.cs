using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcCore.Services;

namespace MvcCore.Models
{
    public class FilmRatingViewModel
    {
        public string FilmId { get; set; }

        [Display(Name = "Added")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Nickname")]
        public string Nickname { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Rating")]
        public int Rating { get; set; }

        public SelectList AllowedRatings => new SelectList(IFilmsService.AllowedRatings());
    }
}
