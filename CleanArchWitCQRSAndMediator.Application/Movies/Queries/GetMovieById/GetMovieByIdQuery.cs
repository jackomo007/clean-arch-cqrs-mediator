using CleanArchWitCQRSAndMediator.Application.Movies.Queries.GetMovies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchWitCQRSAndMediator.Application.Movies.Queries.GetMovieById
{
    public class GetMovieByIdQuery: IRequest<MovieVm>
    {
        public int MovieId { get; set; }
    }
}
