using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetCoolMovies.Core.Domain
{
    public partial class Genre
    {
        public Genre()
        {
            MovieGenres = new HashSet<MovieGenres>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MovieGenres> MovieGenres { get; set; }
    }
}
