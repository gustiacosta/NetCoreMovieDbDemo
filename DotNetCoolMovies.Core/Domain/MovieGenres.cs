#nullable disable

namespace DotNetCoolMovies.Core.Domain
{
    public partial class MovieGenres
    {
        public long Id { get; set; }
        public long MovieId { get; set; }
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
