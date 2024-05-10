using CleanArchWitCQRSAndMediator.Application.Movies.Queries.GetMovies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchWitCQRSAndMediator.Application.Movies.Commands.CreateMovie
{
    public class CreateMovieCommand : IRequest<MovieVm>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
    }
}
