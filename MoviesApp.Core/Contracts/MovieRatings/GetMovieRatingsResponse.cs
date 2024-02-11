namespace MoviesApp.Core.Contracts.MovieRatings
{
	public class GetMovieRatingsResponse
	{
        public IEnumerable<MovieRatingItem>? Data { get; set; }
    }
}

