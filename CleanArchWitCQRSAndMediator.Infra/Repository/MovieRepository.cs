using CleanArchWitCQRSAndMediator.Domain.Entity;
using CleanArchWitCQRSAndMediator.Domain.Repository;
using CleanArchWitCQRSAndMediator.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchWitCQRSAndMediator.Infra.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _movieDbContext;

        public MovieRepository(MovieDbContext movieDbContext) {
            _movieDbContext = movieDbContext;
        }

        public async Task<Movie> CreateAsync(Movie movie)
        {
            await _movieDbContext.Movies.AddAsync(movie);
            await _movieDbContext.SaveChangesAsync();
            return movie;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _movieDbContext.Movies
                .Where(model=>model.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _movieDbContext.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _movieDbContext.Movies
                .AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id);
        }

        public async Task<int> UpdateAsync(int id, Movie movie)
        {
            return await _movieDbContext.Movies
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, movie.Id)
                    .SetProperty(m => m.Title, movie.Title)
                    .SetProperty(m => m.Description, movie.Description)
                    .SetProperty(m => m.Author, movie.Author)
                    .SetProperty(m => m.ImageUrl, movie.ImageUrl)
                );
        }
    }
}
