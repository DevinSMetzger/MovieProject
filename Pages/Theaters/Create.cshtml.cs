using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Movie.Data;
using Movie.Models;

namespace Movie.Pages.Theaters
{
    public class CreateModel : PageModel
    {
        private readonly Movie.Data.MovieContext _context;

        public CreateModel(Movie.Data.MovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Theater Theater { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Theater.Add(Theater);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
