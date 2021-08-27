using Movies.Domain.Models;
using System;
using System.Collections.Generic;

namespace Movies.Domain
{
    public class Movie
    {
        private Movie() { }
        public Movie(string language,string location,string plot,string poster,List<string> soundEffects,List<string> stills,string title,
                            string imdbId, ListingType listingType,string imdbRating)
        {
            Language = language;
            Location = location;    
            Plot = plot;
            Poster = poster;
            SoundEffects = soundEffects;
            Stills= stills;
            Title = title;
            ImdbID = imdbId;
            ListingType = listingType;
            ImdbRating = imdbRating;
        }
        public string Language { get; set; }
        public string Location { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public List<string> SoundEffects { get; set; }
        public List<string> Stills { get; set; }
        public string Title { get; set; }
        public string ImdbID { get; set; }
        public ListingType ListingType { get; set; }
        public string ImdbRating { get; set; }
    }

    public class Root
    {
        public List<Movie> Movies {  get; set; }
    }

}
