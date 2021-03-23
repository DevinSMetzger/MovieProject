using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Movie.Data;
using Movie.Models;

namespace Movie.Pages.Purchases
{
    public class IndexModel : PageModel
    {
        private readonly Movie.Data.MovieContext _context;

        public IndexModel(Movie.Data.MovieContext context)
        {
            _context = context;
        }

        public IList<Purchase> Purchase { get;set; }

        public async Task OnGetAsync()
        {
            Purchase = await _context.Purchase.ToListAsync();
        }
    }
}
