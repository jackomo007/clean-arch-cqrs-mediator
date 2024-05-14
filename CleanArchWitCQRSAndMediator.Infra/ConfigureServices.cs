using AutoMapper;
using CleanArchWitCQRSAndMediator.Domain.Repository;
using CleanArchWitCQRSAndMediator.Infra.Data;
using CleanArchWitCQRSAndMediator.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchWitCQRSAndMediator.Infra
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices
     (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovieDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("MoviedbContext") ??
                    throw new InvalidOperationException("Connection string 'MoviedbContext' not found!"))
            );
            services.AddTransient<IMovieRepository, MovieRepository>();
            return services;
        }

    }
}
