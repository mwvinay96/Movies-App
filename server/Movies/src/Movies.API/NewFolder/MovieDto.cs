using Movies.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API.NewFolder
{
    public class MovieDto
    {
        public string Title { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public string Language { get; set; }
        public decimal Rating { get; set; }
        public string Location { get; set; }
        public string ImdbId { get; set; }
        public ListingType ListingType { get; set; }

    }

}
