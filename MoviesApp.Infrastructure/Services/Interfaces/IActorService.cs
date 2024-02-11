using System;
using MoviesApp.Core.Contracts.Actors;

namespace MoviesApp.Infrastructure.Services.Interfaces
{
	public interface IActorService
	{
        Task<GetActorsResponse> GetAllActors(GetActorsRequest request);
        Task<ActorItem> GetActorById(int request);
        Task<GetActorDetailsResposne> GetActorDetails(int request);
        Task<ActorItem> AddActor(AddActorRequest request);
        Task<ActorItem> UpdateActor(UpdateActorRequest request);
        Task<bool> Delete(int id);
    }
}

