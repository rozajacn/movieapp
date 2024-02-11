namespace MoviesApp.Core.Contracts.Movies
{
	public class GetMoviesResponse
	{
        public IEnumerable<MovieItem>? Data { get; set; }
    }
}

