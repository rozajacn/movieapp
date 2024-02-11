using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Core.Entities
{
	public class MovieRating
	{
        [Key]
        public int Id { get; set; } // Primary key

        public int MovieId { get; set; } // Foreign key referencing the Movie entity
        public Movie Movie { get; set; } // Navigation property to the Movie entity

        public double Rating { get; set; } // Rating given by the user (can be on a scale of 1 to 5, for example)

        public DateTime RatedAt { get; set; } // Date and time when the movie was rated

    }
}

