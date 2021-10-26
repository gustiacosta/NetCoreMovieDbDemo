#nullable disable

namespace DotNetCoolMovies.Core.Domain
{
    public partial class MovieActors
    {
        public long Id { get; set; }
        public long MovieId { get; set; }
        public int ActorId { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
