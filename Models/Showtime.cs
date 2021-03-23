using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class Showtime
    {
        public int ID { get; set; }

        [Display(Name = "Showtime")]
        [DataType(DataType.DateTime)]
        public DateTime Time { get; set; }

        [Display(Name = "Movie ID")]
        public int MovieID { get; set; }

        [Display(Name = "Movie Name")]
        public string movieTitle { get; set; }


        [Display(Name = "Theater ID")]
        public int TheaterID { get; set; }

        [Display(Name = "Theater Location")]
        public string TheaterLocation { get; set; }


    }
}
