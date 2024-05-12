using CleanArchWitCQRSAndMediator.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchWitCQRSAndMediator.Infra.Data
{
    public class MovieDbContext: DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> dbContextOptions) 
            : base(dbContextOptions)
        {
            
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
