using CleanArchWitCQRSAndMediator.Domain.Entity;
using CleanArchWitCQRSAndMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchWitCQRSAndMediator.Application.Movies.Commands.DeleteMovie
{
    internal class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, int>
    {
        private readonly IMovieRepository _movieRepository;
        
        public DeleteMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<int> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
            return await _movieRepository.DeleteAsync(request.Id);
        }
    }
}
