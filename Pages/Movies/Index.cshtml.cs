﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movie.Data;
using Movie.Models;

namespace Movie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Movie.Data.MovieContext _context;

        public IndexModel(Movie.Data.MovieContext context)
        {
            _context = context;
        }

        public IList<MovieItem> MovieItem { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal maxPrice { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal minRating { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;
            
            var movies = from m in _context.Movie
                         select m;

            if (maxPrice != 0)
            {
                movies = movies.Where(x => x.Price <= maxPrice);
            }

            if (minRating != 0)
            {
                movies = movies.Where(x => x.Rating >= minRating);
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            MovieItem = await movies.ToListAsync();
        }
    }
}
