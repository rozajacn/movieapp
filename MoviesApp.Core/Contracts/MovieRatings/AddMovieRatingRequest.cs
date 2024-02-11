namespace MoviesApp.Core.Contracts.MovieRatings
{
	public class AddMovieRatingRequest
	{
        public int MovieId { get; set; }

        public double Rating { get; set; }
    }
}

