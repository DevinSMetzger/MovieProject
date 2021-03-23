using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Movie.Data;
using Movie.Models;

namespace Movie.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private readonly Movie.Data.MovieContext _context;

        public DeleteModel(Movie.Data.MovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MovieItem MovieItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MovieItem = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            if (MovieItem == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MovieItem = await _context.Movie.FindAsync(id);

            if (MovieItem != null)
            {
                _context.Movie.Remove(MovieItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
