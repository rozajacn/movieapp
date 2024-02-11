using MoviesApp.Core.Contracts.Movies;

namespace MoviesApp.Infrastructure.Services.Interfaces
{
	public interface IMovieService
	{
        Task<GetMoviesResponse> GetAllMovies(GetMoviesRequest request);
        Task<MovieItem> GetMovieById(int request);
        Task<GetMovieDetailsResponse> GetMovieDetails(int request);
        Task<MovieItem> AddMovie(AddMovieItemRequest request);
        Task<MovieItem> UpdateMovie(UpdateMovieItemRequest request);
        Task<bool> AddMovieActor(AddMovieActorAssociationRequest request);
        Task<bool> Delete(int id);
    }
}

