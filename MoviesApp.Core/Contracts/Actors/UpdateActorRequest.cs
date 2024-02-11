using System;
namespace MoviesApp.Core.Contracts.Actors
{
	public class UpdateActorRequest
	{
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Biography { get; set; }
    }
}

