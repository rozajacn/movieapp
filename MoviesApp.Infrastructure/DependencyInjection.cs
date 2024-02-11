using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoviesApp.Infrastructure.Data;
using MoviesApp.Infrastructure.Services.Implemetations;
using MoviesApp.Infrastructure.Services.Interfaces;

namespace MoviesApp.Infrastructure
{
    public static class DependencyInjection
	{
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IHostEnvironment env)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IActorService, ActorService>();
            services.AddScoped<IMovieRatingService, MovieRatingService>();

            return services;
        }
    }
}

