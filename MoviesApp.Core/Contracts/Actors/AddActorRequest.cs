using System;
namespace MoviesApp.Core.Contracts.Actors
{
	public class AddActorRequest
	{
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Biography { get; set; }
    }
}

