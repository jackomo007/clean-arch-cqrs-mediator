using CleanArchWitCQRSAndMediator.Application.Common.Mappings;
using CleanArchWitCQRSAndMediator.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchWitCQRSAndMediator.Application.Movies.Queries.GetMovies
{
    public class MovieVm: IMapFrom<Movie>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
