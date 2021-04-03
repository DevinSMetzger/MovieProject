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

namespace Movie.Pages.Showtimes
{
    public class IndexModel : PageModel
    {
        private readonly Movie.Data.MovieContext _context;
        public IList<Showtime> ShowtimesItem { get; set; }

        [BindProperty(SupportsGet = true)]
        public string TitleSearch { get; set; }

        public SelectList LocationItems { get; set; }
        [BindProperty(SupportsGet = true)]
        public string LocationSearch { get; set; }

        public IndexModel(Movie.Data.MovieContext context)
        {
            _context = context;
        }

        public IList<Showtime> Showtime { get;set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> locationQuery = from m in _context.Showtime
                                            orderby m.TheaterLocation
                                            select m.TheaterLocation;

            var showtimes = from m in _context.Showtime
                         select m;

            if (!string.IsNullOrEmpty(LocationSearch))
            {
                showtimes = showtimes.Where(x => x.TheaterLocation == LocationSearch);
            }

            if (!string.IsNullOrEmpty(TitleSearch))
            {
                showtimes = showtimes.Where(s => s.movieTitle.Contains(TitleSearch));
            }
            LocationItems = new SelectList(await locationQuery.Distinct().ToListAsync());
            ShowtimesItem = await showtimes.ToListAsync();

        }
    }
}
