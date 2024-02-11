using Microsoft.EntityFrameworkCore;
using MoviesApp.Core.Entities;

namespace MoviesApp.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Actor> Actors => Set<Actor>();
        public DbSet<MovieActor> MovieActors => Set<MovieActor>();
        public DbSet<MovieRating> MovieRatings => Set<MovieRating>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "The Shawshank Redemption",
                    ReleaseYear = 1994,
                    Director = "Frank Darabont",
                    Description = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                    Rating = 9.3,
                    Genre = "Drama",
                    Writers = "Stephen King (short story \"Rita Hayworth and Shawshank Redemption\"), Frank Darabont (screenplay)"
                },
                new Movie
                {
                    Id = 2,
                    Title = "The Godfather",
                    ReleaseYear = 1972,
                    Director = "Francis Ford Coppola",
                    Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                    Rating = 9.2,
                    Genre = "Crime, Drama",
                    Writers = "Mario Puzo (screenplay by), Francis Ford Coppola (screenplay by)"
                },
                new Movie
                {
                    Id = 3,
                    Title = "The Dark Knight",
                    ReleaseYear = 2008,
                    Director = "Christopher Nolan",
                    Description = "When the menace known as The Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                    Rating = 9.0,
                    Genre = "Action, Crime, Drama",
                    Writers = "Jonathan Nolan (screenplay), Christopher Nolan (screenplay)"
                },
                new Movie
                {
                    Id = 4,
                    Title = "Schindler's List",
                    ReleaseYear = 1993,
                    Director = "Steven Spielberg",
                    Description = "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis.",
                    Rating = 8.9,
                    Genre = "Biography, Drama, History",
                    Writers = "Thomas Keneally (book), Steven Zaillian (screenplay)"
                },
                new Movie
                {
                    Id = 5,
                    Title = "The Lord of the Rings: The Return of the King",
                    ReleaseYear = 2003,
                    Director = "Peter Jackson",
                    Description = "Gandalf and Aragorn lead the World of Men against Sauron's army to draw his gaze from Frodo and Sam as they approach Mount Doom with the One Ring.",
                    Rating = 8.9,
                    Genre = "Action, Adventure, Drama",
                    Writers = "J.R.R. Tolkien (novel), Fran Walsh (screenplay)"
                }
            );

            modelBuilder.Entity<Actor>().HasData(
                // Actors for The Shawshank Redemption
                new Actor
                {
                    Id = 1,
                    FirstName = "Tim",
                    LastName = "Robbins",
                    Biography = "Tim Robbins was born in West Covina, California, to Mary Robbins (née Bledsoe), an actress, and Gilbert Lee Robbins, a musician, folk singer, actor, and former manager of The Gaslight Cafe. Robbins studied drama at UCLA, where he graduated with honors in 1981.",
                    DateOfBirth = new DateTime(1958, 10, 16)
                },
                new Actor
                {
                    Id = 2,
                    FirstName = "Morgan",
                    LastName = "Freeman",
                    Biography = "With an authoritative voice and calm demeanor, this ever-popular American actor has grown into one of the most respected figures in modern US cinema. Morgan was born on June 1, 1937 in Memphis, Tennessee, to Mayme Edna (Revere), a teacher, and Morgan Porterfield Freeman, a barber.",
                    DateOfBirth = new DateTime(1937, 6, 1)
                },

                // Actors for The Godfather
                new Actor
                {
                    Id = 3,
                    FirstName = "Marlon",
                    LastName = "Brando",
                    Biography = "Marlon Brando is widely considered the greatest movie actor of all time, rivaled only by the more theatrically oriented Laurence Olivier in terms of esteem.",
                    DateOfBirth = new DateTime(1924, 4, 3)
                },
                new Actor
                {
                    Id = 4,
                    FirstName = "Al",
                    LastName = "Pacino",
                    Biography = "Alfredo James 'Al' Pacino established himself as a film actor during one of cinema's most vibrant decades, the 1970s, and has become an enduring and iconic figure in the world of American movies.",
                    DateOfBirth = new DateTime(1940, 4, 25)
                },

                // Actors for The Dark Knight
                new Actor
                {
                    Id = 5,
                    FirstName = "Christian",
                    LastName = "Bale",
                    Biography = "Christian Charles Philip Bale was born in Pembrokeshire, Wales, UK on January 30, 1974, to English parents Jennifer 'Jenny' (James) and David Bale.",
                    DateOfBirth = new DateTime(1974, 1, 30)
                },
                new Actor
                {
                    Id = 6,
                    FirstName = "Heath",
                    LastName = "Ledger",
                    Biography = "When hunky, twenty-year-old heart-throb Heath Ledger first came to the attention of the public in 1999, it was all too easy to tag him as a 'pretty boy' and an actor of little depth.",
                    DateOfBirth = new DateTime(1979, 4, 4)
                },

                // Actors for Schindler's List
                new Actor
                {
                    Id = 7,
                    FirstName = "Liam",
                    LastName = "Neeson",
                    Biography = "Liam Neeson was born on June 7, 1952 in Ballymena, Northern Ireland, to Katherine (Brown), a cook, and Bernard Neeson, a school caretaker.",
                    DateOfBirth = new DateTime(1952, 6, 7)
                },
                new Actor
                {
                    Id = 8,
                    FirstName = "Ben",
                    LastName = "Kingsley",
                    Biography = "Ben Kingsley was born Krishna Bhanji on December 31, 1943 in Scarborough, Yorkshire, England. His father, Rahimtulla Harji Bhanji, was a Kenyan-born medical doctor, of Gujarati Indian descent, and his mother, Anna Lyna Mary (Goodman), was an English actress.",
                    DateOfBirth = new DateTime(1943, 12, 31)
                },

                // Actors for The Lord of the Rings: The Return of the King
                new Actor
                {
                    Id = 9,
                    FirstName = "Elijah",
                    LastName = "Wood",
                    Biography = "Elijah Wood is an American actor best known for portraying Frodo Baggins in Peter Jackson's blockbuster Lord of the Rings film trilogy.",
                    DateOfBirth = new DateTime(1981, 1, 28)
                },
                new Actor
                {
                    Id = 10,
                    FirstName = "Ian",
                    LastName = "McKellen",
                    Biography = "Widely regarded as one of greatest stage and screen actors both in his native Great Britain and internationally, twice nominated for the Oscar and recipient of every major theatrical award in the UK and US, Ian Murray McKellen was born on May 25, 1939 in Burnley, Lancashire, England, to Margery Lois (Sutcliffe) and Denis Murray McKellen, a civil engineer and lay preacher.",
                    DateOfBirth = new DateTime(1939, 5, 25)
                }
            );

            modelBuilder.Entity<MovieActor>().HasData(
                // Movie 1: The Shawshank Redemption
                new MovieActor { Id = 1, MovieId = 1, ActorId = 1 }, // Tim Robbins
                new MovieActor { Id = 2, MovieId = 1, ActorId = 2 }, // Morgan Freeman

                // Movie 2: The Godfather
                new MovieActor { Id = 3, MovieId = 2, ActorId = 3 }, // Marlon Brando
                new MovieActor { Id = 4, MovieId = 2, ActorId = 4 }, // Al Pacino

                // Movie 3: The Dark Knight
                new MovieActor { Id = 5, MovieId = 3, ActorId = 5 }, // Christian Bale
                new MovieActor { Id = 6, MovieId = 3, ActorId = 6 }, // Heath Ledger

                // Movie 4: Schindler's List
                new MovieActor { Id = 7, MovieId = 4, ActorId = 7 }, // Liam Neeson
                new MovieActor { Id = 8, MovieId = 4, ActorId = 8 }, // Ben Kingsley

                // Movie 5: The Lord of the Rings: The Return of the King
                new MovieActor { Id = 9, MovieId = 5, ActorId = 9 }, // Elijah Wood
                new MovieActor { Id = 10, MovieId = 5, ActorId = 10 } // Ian McKellen
            );

            modelBuilder.Entity<MovieRating>().HasData(
                new MovieRating { Id = 1, MovieId = 1, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 7.3 },
                new MovieRating { Id = 2, MovieId = 1, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 9 },
                new MovieRating { Id = 3, MovieId = 1, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 8.9 },
                new MovieRating { Id = 4, MovieId = 1, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 9.3 },
                new MovieRating { Id = 5, MovieId = 2, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 9.5 },
                new MovieRating { Id = 6, MovieId = 2, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 7.3 },
                new MovieRating { Id = 7, MovieId = 2, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 9 },
                new MovieRating { Id = 8, MovieId = 2, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 8.9 },
                new MovieRating { Id = 9, MovieId = 3, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 9.3 },
                new MovieRating { Id = 10, MovieId = 3, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 9.5 },
                new MovieRating { Id = 11, MovieId = 3, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 7.3 },
                new MovieRating { Id = 12, MovieId = 3, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 9 },
                new MovieRating { Id = 13, MovieId = 3, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 8.9 },
                new MovieRating { Id = 14, MovieId = 3, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 9.3 },
                new MovieRating { Id = 15, MovieId = 4, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 9.5 },
                new MovieRating { Id = 16, MovieId = 4, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 7.3 },
                new MovieRating { Id = 17, MovieId = 4, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 9 },
                new MovieRating { Id = 18, MovieId = 4, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 8.9 },
                new MovieRating { Id = 19, MovieId = 4, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 9.3 },
                new MovieRating { Id = 20, MovieId = 4, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 9.5 },
                new MovieRating { Id = 21, MovieId = 5, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 7.3 },
                new MovieRating { Id = 22, MovieId = 5, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 9 },
                new MovieRating { Id = 23, MovieId = 5, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 8.9 },
                new MovieRating { Id = 24, MovieId = 5, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 9.3 },
                new MovieRating { Id = 25, MovieId = 5, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 9.5 },
                new MovieRating { Id = 26, MovieId = 5, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 7.3 },
                new MovieRating { Id = 27, MovieId = 5, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 9 },
                new MovieRating { Id = 28, MovieId = 5, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 8.9 },
                new MovieRating { Id = 29, MovieId = 5, RatedAt = DateTime.Now.AddDays(new Random().Next(-365 * 100, 365 * 100)), Rating = 9.3 }
            );
        }
    }
}

