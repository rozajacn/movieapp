using System;
using MoviesApp.Core.Contracts.Actors;
using MoviesApp.Core.Contracts.MovieRatings;
using MoviesApp.Core.Entities;
using MoviesApp.Infrastructure.Data;
using MoviesApp.Infrastructure.Services.Interfaces;

namespace MoviesApp.Infrastructure.Services.Implemetations
{
	public class MovieRatingService : IMovieRatingService
	{
        private readonly ApplicationDbContext _dbContext;

        public MovieRatingService(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

        public async Task<GetMovieRatingsResponse> GetMovieRatings(GetMovieRatingsRequest request)
        {
            GetMovieRatingsResponse response = new GetMovieRatingsResponse();

            try
            {
                response.Data = _dbContext.MovieRatings.Where(x => x.Id == request.MovieId)
                    .Select(x => new MovieRatingItem
                    {
                        Id = x.Id,
                        MovieId = x.MovieId,
                        RatedAt = x.RatedAt,
                        Rating = x.Rating
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return response;
        }

        public async Task AddMovieRating(AddMovieRatingRequest request)
        {
            try
            {
                MovieRating rating = new MovieRating
                {
                    MovieId = request.MovieId,
                    RatedAt = DateTime.Now,
                    Rating = request.Rating
                };

                await _dbContext.MovieRatings.AddAsync(rating);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
    }
}

