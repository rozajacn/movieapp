using System;
using MoviesApp.Core.Entities;

namespace MoviesApp.Core.Contracts.Actors
{
	public class ActorItem
	{
        public int Id { get; set; } 

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Biography { get; set; }
    }
}

