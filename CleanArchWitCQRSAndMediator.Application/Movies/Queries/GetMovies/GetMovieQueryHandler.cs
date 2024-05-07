using AutoMapper;
using CleanArchWitCQRSAndMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchWitCQRSAndMediator.Application.Movies.Queries.GetMovies
{
    public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, List<MovieVm>>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public GetMovieQueryHandler(IMovieRepository movieRepository, IMapper mapper) {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<List<MovieVm>> Handle(GetMovieQuery request, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.GetAllMoviesAsync();
            var moviesList = movies.Select(x => new MovieVm { 
                Author = x.Author, Title = x.Title, 
                Description = x.Description , Id = x.Id 
            }).ToList();

            return moviesList;
        }
    }
}
