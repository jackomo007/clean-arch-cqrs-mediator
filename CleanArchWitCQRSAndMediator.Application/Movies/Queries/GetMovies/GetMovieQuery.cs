using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchWitCQRSAndMediator.Application.Movies.Queries.GetMovies
{
    public class GetMovieQuery: IRequest<List<MovieVm>>
    {

    }
}
