using System;
using MoviesApp.Core.Contracts.MovieRatings;

namespace MoviesApp.Infrastructure.Services.Interfaces
{
	public interface IMovieRatingService
	{
        Task<GetMovieRatingsResponse> GetMovieRatings(GetMovieRatingsRequest request);
        Task AddMovieRating(AddMovieRatingRequest request);
    }
}

