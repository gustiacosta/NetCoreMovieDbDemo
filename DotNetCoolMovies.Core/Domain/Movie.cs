using System.Collections.Generic;

#nullable disable

namespace DotNetCoolMovies.Core.Domain
{
    public partial class Movie
    {
        public Movie()
        {
            Actors = new HashSet<MovieActors>();
            Genres = new HashSet<MovieGenres>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

        public virtual ICollection<MovieActors> Actors { get; set; }
        public virtual ICollection<MovieGenres> Genres { get; set; }
    }
}
