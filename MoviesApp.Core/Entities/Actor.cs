using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Core.Entities
{
	public class Actor
	{
        [Key]
        public int Id { get; set; } // Primary key

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Biography { get; set; }

        public ICollection<MovieActor> MovieActors { get; set; }
    }
}

