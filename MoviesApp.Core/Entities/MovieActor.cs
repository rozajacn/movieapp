using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Core.Entities
{
	public class MovieActor
	{
        [Key]
        public int Id { get; set; } // Primary key

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}

