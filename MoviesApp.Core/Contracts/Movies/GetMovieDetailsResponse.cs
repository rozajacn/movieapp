using MoviesApp.Core.Contracts.Actors;
using MoviesApp.Core.Contracts.MovieRatings;

namespace MoviesApp.Core.Contracts.Movies
{
	public class GetMovieDetailsResponse
	{
        public MovieItem MovieItem { get; set; }
        public IEnumerable<ActorItem>? Actors { get; set; }
        public IEnumerable<MovieRatingItem> MovieRatings { get; set; }
    }
}

