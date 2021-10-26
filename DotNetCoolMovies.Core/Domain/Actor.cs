using System.Collections.Generic;

#nullable disable

namespace DotNetCoolMovies.Core.Domain
{
    public partial class Actor
    {
        public Actor()
        {
            MovieActors = new HashSet<MovieActors>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MovieActors> MovieActors { get; set; }
    }
}
