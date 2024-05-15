using CleanArchWitCQRSAndMediator.Domain.Entity;
using CleanArchWitCQRSAndMediator.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchWitCQRSAndMediator.Application.Movies.Commands.UpdateMovie
{
    public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, int>
    {
        private readonly IMovieRepository _movieRepository;
        
        public UpdateMovieCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<int> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var UpdateMovieEntity = new Movie()
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description,
                Author = request.Author,
                ImageUrl = request.ImageUrl,
            };
            return await _movieRepository.UpdateAsync(request.Id, UpdateMovieEntity);
        }
    }
}
