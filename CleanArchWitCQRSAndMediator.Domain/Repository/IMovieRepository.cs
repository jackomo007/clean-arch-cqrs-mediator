using CleanArchWitCQRSAndMediator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchWitCQRSAndMediator.Domain.Repository
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllMoviesAsync();
        Task<Movie> GetMovieByIdAsync(int id);
        Task<Movie> CreateAsync(Movie movie);
        Task<int> UpdateAsync(int id, Movie movie);
        Task<int> DeleteAsync(int id);
    }
}
