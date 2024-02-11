using System;
namespace MoviesApp.Core.Contracts.Movies
{
	public class AddMovieActorAssociationRequest
	{
		public int MovieId { get; set; }
		public int ActorId { get; set; }
	}
}

