using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movie.Models;

namespace Movie.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext (DbContextOptions<MovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie.Models.MovieItem> Movie { get; set; }

        public DbSet<Movie.Models.Purchase> Purchase { get; set; }

        public DbSet<Movie.Models.Showtime> Showtime { get; set; }

        public DbSet<Movie.Models.Theater> Theater { get; set; }
    }
}
