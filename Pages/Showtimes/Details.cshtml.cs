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
    public class DetailsModel : PageModel
    {
        private readonly Movie.Data.MovieContext _context;

        public DetailsModel(Movie.Data.MovieContext context)
        {
            _context = context;
        }

        public Showtime Showtime { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Showtime = await _context.Showtime.FirstOrDefaultAsync(m => m.ID == id);

            if (Showtime == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
