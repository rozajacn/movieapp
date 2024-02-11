using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Core.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; } // Primary key

        public string Title { get; set; }

        public string Description { get; set; }

        public string Director { get; set; }

        public string Writers { get; set; }

        public int ReleaseYear { get; set; }

        public double Rating { get; set; }

        public string Genre { get; set; }

        public ICollection<MovieActor> MovieActors { get; set; }
    }
}

