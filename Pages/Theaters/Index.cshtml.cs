using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movie.Data;
using Movie.Models;

namespace Movie.Pages.Theaters
{
    public class IndexModel : PageModel
    {
        private readonly Movie.Data.MovieContext _context;


        [BindProperty(SupportsGet = true)]
        public string TheaterLocation { get; set; }
        public SelectList Locations { get; set; }
        public IndexModel(Movie.Data.MovieContext context)
        {
            _context = context;
        }

        public IList<Theater> Theater { get;set; }

        public async Task OnGetAsync()
        {

            IQueryable<string> locationQuery = from m in _context.Theater
                                            orderby m.Location
                                            select m.Location;

            var theaters = from m in _context.Theater
                         select m;

            if (!string.IsNullOrEmpty(TheaterLocation))
            {
                theaters = theaters.Where(x => x.Location == TheaterLocation);
            }

            Locations = new SelectList(await locationQuery.Distinct().ToListAsync());
            Theater = await theaters.ToListAsync();
        }
    }
}
