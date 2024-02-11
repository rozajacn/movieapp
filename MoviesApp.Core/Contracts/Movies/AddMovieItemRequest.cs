using System;
namespace MoviesApp.Core.Contracts.Movies
{
	public class AddMovieItemRequest
	{
        public string Title { get; set; }

        public string Description { get; set; }

        public string Director { get; set; }

        public string Writers { get; set; }

        public int ReleaseYear { get; set; }

        public double Rating { get; set; }

        public string Genre { get; set; }
    }
}

