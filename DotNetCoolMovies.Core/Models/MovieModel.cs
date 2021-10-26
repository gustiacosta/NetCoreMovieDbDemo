using System.Collections.Generic;

#nullable disable

namespace DotNetCoolMovies.Core.Models
{
    public partial class MovieModel
    {
        public MovieModel()
        {
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

        public IEnumerable<ActorModel> Actors { get; set; }
        public IEnumerable<GenreModel> Genres { get; set; }
    }
}
