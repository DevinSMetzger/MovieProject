using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Movie.Data;
using Movie.Models;

namespace Movie.Pages.Showtimes
{
    public class IndexModel : PageModel
    {
        private readonly Movie.Data.MovieContext _context;

        public IndexModel(Movie.Data.MovieContext context)
        {
            _context = context;
        }

        public IList<Showtime> Showtime { get;set; }

        public async Task OnGetAsync()
        {
            Showtime = await _context.Showtime.ToListAsync();
        }
    }
}
