using System;
using MoviesApp.Core.Contracts.Movies;

namespace MoviesApp.Core.Contracts.Actors
{
	public class GetActorDetailsResposne
	{
        public ActorItem ActorItem { get; set; }
        public IEnumerable<MovieItem>? Movies { get; set; }
    }
}

