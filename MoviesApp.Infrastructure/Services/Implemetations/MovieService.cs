using Microsoft.EntityFrameworkCore;
using MoviesApp.Core.Contracts.Actors;
using MoviesApp.Core.Contracts.MovieRatings;
using MoviesApp.Core.Contracts.Movies;
using MoviesApp.Core.Entities;
using MoviesApp.Infrastructure.Data;
using MoviesApp.Infrastructure.Services.Interfaces;

namespace MoviesApp.Infrastructure.Services.Implemetations
{
	public class MovieService : IMovieService
	{
        private readonly ApplicationDbContext _dbContext;

        public MovieService(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<GetMoviesResponse> GetAllMovies(GetMoviesRequest request)
		{
			GetMoviesResponse response = new GetMoviesResponse();

			try
			{
				response.Data = _dbContext.Movies.Where(x => request.Search == null || x.Title.ToLower().Contains(request.Search.ToLower()))
					.Select(x => new MovieItem
					{
						Id = x.Id,
						Title = x.Title,
						Description = x.Description,
						Director = x.Director,
						Genre = x.Genre,
						ReleaseYear = x.ReleaseYear,
						Writers = x.Writers,
						Rating = x.Rating
					});
            }
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}

			return response;
		}

        public async Task<MovieItem> GetMovieById(int request)
        {
            MovieItem response = new MovieItem();

            try
            {
				var item = await _dbContext.Movies.FindAsync(request);

				response = new MovieItem
				{
					Id = item.Id,
					Description = item.Description,
					Title = item.Title,
					Director = item.Director,
					Genre = item.Genre,
					Rating = item.Rating,
					ReleaseYear = item.ReleaseYear,
					Writers = item.Writers
				};
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return response;
        }

        public async Task<GetMovieDetailsResponse> GetMovieDetails(int request)
        {
            GetMovieDetailsResponse response = new GetMovieDetailsResponse();

            try
            {
                var item = await _dbContext.Movies.FindAsync(request);

                if (item == null)
                {
                    return null; // Movie not found
                }

                response.MovieItem = new MovieItem
                {
                    Id = item.Id,
                    Description = item.Description,
                    Title = item.Title,
                    Director = item.Director,
                    Genre = item.Genre,
                    Rating = item.Rating,
                    ReleaseYear = item.ReleaseYear,
                    Writers = item.Writers
                };

                response.Actors = await GetActorsByMovieId(request);

                response.MovieRatings = await _dbContext.MovieRatings
                    .Where(x => x.MovieId == request)
                    .Select(x => new MovieRatingItem
                    {
                        Id = x.Id,
                        MovieId = item.Id,
                        RatedAt = x.RatedAt,
                        Rating = x.Rating
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return response;
        }

        private async Task<List<ActorItem>> GetActorsByMovieId(int movieId)
        {
            var actors = new List<ActorItem>();
            try
            {
                actors = await _dbContext.MovieActors
                    .Where(x => x.MovieId == movieId)
                    .Select(x => new ActorItem
                    {
                        Id = x.Actor.Id,
                        FirstName = x.Actor.FirstName,
                        LastName = x.Actor.LastName,
                        Biography = x.Actor.Biography,
                        DateOfBirth = x.Actor.DateOfBirth
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return actors;
        }

        public async Task<MovieItem> AddMovie(AddMovieItemRequest request)
        {
            MovieItem response = new MovieItem();

            try
            {
                Movie movie = new Movie
                {
                    Description = request.Description,
                    Title = request.Title,
                    Director = request.Director,
                    Genre = request.Genre,
                    Rating = request.Rating,
                    ReleaseYear = request.ReleaseYear,
                    Writers = request.Writers
                };

                await _dbContext.Movies.AddAsync(movie);
                await _dbContext.SaveChangesAsync();

                return await GetMovieById(movie.Id);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

            return response;
        }

        public async Task<MovieItem> UpdateMovie(UpdateMovieItemRequest request)
        {
            MovieItem response = new MovieItem();

            try
            {
                Movie movie = await _dbContext.Movies.FindAsync(request.Id);

                movie.Title = request.Title;
                movie.Description = request.Description;
                movie.Director = request.Director;
                movie.Genre = request.Genre;
                movie.Rating = request.Rating;
                movie.ReleaseYear = request.ReleaseYear;
                movie.Writers = request.Writers;

                _dbContext.Update(movie);
                await _dbContext.SaveChangesAsync();

                return await GetMovieById(movie.Id);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

            return response;
        }

        public async Task<bool> AddMovieActor(AddMovieActorAssociationRequest request)
        {
            try
            {
                // Check if the movie and actor exist
                var movie = await _dbContext.Movies.FindAsync(request.MovieId);
                var actor = await _dbContext.Actors.FindAsync(request.ActorId);

                if (movie == null || actor == null)
                {
                    return false;
                }

                // Check if the association already exists
                var existingAssociation = await _dbContext.MovieActors
                    .FirstOrDefaultAsync(ma => ma.MovieId == request.MovieId && ma.ActorId == request.ActorId);

                if (existingAssociation != null)
                {
                    return false;
                }

                // Create a new association
                var movieActor = new MovieActor
                {
                    MovieId = request.MovieId,
                    ActorId = request.ActorId
                };

                // Add the association to the database
                _dbContext.MovieActors.Add(movieActor);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Movie movie = _dbContext.Movies.Find(id);

                if (movie == null)
                {
                    return false; // Movie not found
                }

                _dbContext.Remove(movie);
                _dbContext.SaveChanges();

                return true; // Operation succeeded
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false; // Operation failed due to exception
            }
        }
    }
}

