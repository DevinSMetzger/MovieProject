using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Models
{
    public class Theater
    {
        public int ID { get; set; }
        public String Location { get; set; }
        public int Capacity { get; set; }

        [Display(Name = "IMax Available?")]
        public bool ImaxAvailable { get; set; }
    }
}
