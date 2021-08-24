using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Infrastructure.Data.Configurations
{
    public class MovieMap : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(e => new { e.ImdbID, e.Location });
            builder.Property(e => e.ImdbID);
            builder.Property(e => e.Location);
            builder.Property(e => e.Title);
            builder.Property(e=>e.Language);
            builder.Property(e => e.Plot);
            builder.Property(e => e.Stills).HasConversion(v => JsonConvert.SerializeObject(v), v => JsonConvert.DeserializeObject<List<string>>(v));
            builder.Property(e => e.Poster);
            builder.Property(e=>e.ImdbRating);
            builder.Property(e => e.ListingType);
            builder.Property(e => e.SoundEffects).HasConversion(v => JsonConvert.SerializeObject(v), v => JsonConvert.DeserializeObject<List<string>>(v));
        }
    }
}
