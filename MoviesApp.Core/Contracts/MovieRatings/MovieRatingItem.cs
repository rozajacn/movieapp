using System;
using MoviesApp.Core.Entities;

namespace MoviesApp.Core.Contracts.MovieRatings
{
	public class MovieRatingItem
	{
        public int Id { get; set; } 

        public int MovieId { get; set; } 

        public double Rating { get; set; } 

        public DateTime RatedAt { get; set; } 
    }
}

