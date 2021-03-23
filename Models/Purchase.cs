using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class Purchase
    {
        public int ID { get; set; }

        [Display(Name = "Purchase Time")]
        [DataType(DataType.DateTime)]
        public DateTime currentTime { get; set; }

        [Display(Name = "Showtime ID")]
        public int ShowtimeID { get; set; }

        [Display(Name = "Movie ID")]
        public int MovieID { get; set; }

        [Display(Name = "Theater ID")]
        public int TheaterID { get; set; }

        [Display(Name = "Number of Tickets")]
        public int NumberTickets { get; set; }

    }
}
