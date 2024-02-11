using System;
using MoviesApp.Core.Contracts.Movies;

namespace MoviesApp.Core.Contracts.Actors
{
	public class GetActorsResponse
	{
        public IEnumerable<ActorItem>? Data { get; set; }
    }
}

