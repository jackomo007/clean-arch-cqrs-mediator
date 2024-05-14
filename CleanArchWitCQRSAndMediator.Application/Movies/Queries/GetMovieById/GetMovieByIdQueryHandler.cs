using AutoMapper;
using CleanArchWitCQRSAndMediator.Application.Movies.Queries.GetMovies;
using CleanArchWitCQRSAndMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchWitCQRSAndMediator.Application.Movies.Queries.GetMovieById
{
    public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, MovieVm>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;


        public GetMovieByIdQueryHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }


        public async Task<MovieVm> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetMovieByIdAsync(request.MovieId);
            return _mapper.Map<MovieVm>(movie);
        }
    }
}
