using AutoMapper;
using CleanArchWitCQRSAndMediator.Application.Movies.Queries.GetMovies;
using CleanArchWitCQRSAndMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchWitCQRSAndMediator.Domain.Entity;

namespace CleanArchWitCQRSAndMediator.Application.Movies.Commands.CreateMovie
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, MovieVm>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public CreateMovieCommandHandler(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<MovieVm> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movieEntity = new Movie() { 
                Title = request.Title,
                Description = request.Description,
                Author = request.Author,
                ImageUrl = request.ImageUrl,
            };
            var Result = await _movieRepository.CreateAsync(movieEntity);
            return _mapper.Map<MovieVm>(Result);
        }
    }
}
