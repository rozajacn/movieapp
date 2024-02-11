using System;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Core.Contracts.Actors;
using MoviesApp.Core.Contracts.Movies;
using MoviesApp.Core.Entities;
using MoviesApp.Infrastructure.Data;
using MoviesApp.Infrastructure.Services.Interfaces;

namespace MoviesApp.Infrastructure.Services.Implemetations
{
	public class ActorService : IActorService
	{
        private readonly ApplicationDbContext _dbContext;

        public ActorService(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

        public async Task<GetActorsResponse> GetAllActors(GetActorsRequest request)
        {
            GetActorsResponse response = new GetActorsResponse();

            try
            {
                response.Data = _dbContext.Actors.Where(x => request.Search == null || (x.FirstName.ToLower().Contains(request.Search.ToLower()) || x.LastName.ToLower().Contains(request.Search.ToLower())))
                    .Select(x => new ActorItem
                    {
                        Id = x.Id,
                        Biography = x.Biography,
                        DateOfBirth = x.DateOfBirth,
                        FirstName = x.FirstName,
                        LastName = x.LastName
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return response;
        }

        public async Task<ActorItem> GetActorById(int request)
        {
            ActorItem response = new ActorItem();

            try
            {
                var item = await _dbContext.Actors.FindAsync(request);

                response = new ActorItem
                {
                    Id = item.Id,
                    Biography = item.Biography,
                    DateOfBirth = item.DateOfBirth,
                    FirstName = item.FirstName,
                    LastName = item.LastName
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return response;
        }

        public async Task<GetActorDetailsResposne> GetActorDetails(int request)
        {
            GetActorDetailsResposne response = new GetActorDetailsResposne();

            try
            {
                var item = await _dbContext.Actors.FindAsync(request);

                if (item == null)
                {
                    return null; // Actor not found
                }

                response.ActorItem = new ActorItem
                {
                    Id = item.Id,
                    Biography = item.Biography,
                    DateOfBirth = item.DateOfBirth,
                    FirstName = item.FirstName,
                    LastName = item.LastName
                };

                response.Movies = await GetMoviesByActorId(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return response;
        }

        private async Task<List<MovieItem>> GetMoviesByActorId(int actorId)
        {
            var actors = new List<MovieItem>();
            try
            {
                actors = await _dbContext.MovieActors
                    .Where(x => x.ActorId == actorId)
                    .Select(x => new MovieItem
                    {
                        Id = x.Movie.Id,
                        Title = x.Movie.Title,
                        Description = x.Movie.Description,
                        Director = x.Movie.Director,
                        Genre = x.Movie.Genre,
                        Rating = x.Movie.Rating,
                        ReleaseYear = x.Movie.ReleaseYear,
                        Writers = x.Movie.Writers
                    })
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return actors;
        }

        public async Task<ActorItem> AddActor(AddActorRequest request)
        {
            ActorItem response = new ActorItem();

            try
            {
                Actor actor = new Actor
                {
                    Biography = request.Biography,
                    DateOfBirth = request.DateOfBirth,
                    FirstName = request.FirstName,
                    LastName = request.LastName
                };

                await _dbContext.Actors.AddAsync(actor);
                await _dbContext.SaveChangesAsync();

                return await GetActorById(actor.Id);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

            return response;
        }

        public async Task<ActorItem> UpdateActor(UpdateActorRequest request)
        {
            ActorItem response = new ActorItem();

            try
            {
                Actor actor = await _dbContext.Actors.FindAsync(request.Id);

                actor.Id = request.Id;
                actor.Biography = request.Biography;
                actor.DateOfBirth = request.DateOfBirth;
                actor.FirstName = request.FirstName;
                actor.LastName = request.LastName;

                _dbContext.Update(actor);
                await _dbContext.SaveChangesAsync();

                return await GetActorById(actor.Id);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

            return response;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                Actor actor = _dbContext.Actors.Find(id);

                _dbContext.Remove(actor);

                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }

            return true;
        }
    }
}

