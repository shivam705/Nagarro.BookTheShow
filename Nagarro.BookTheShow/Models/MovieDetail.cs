using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.BookTheShow.Models
{
    public class MovieDetail
    {
        public int Id { get; set; }

        [Required]
        public string MovieName { get; set; }

        [Required]
        public string MovieDescription { get; set; }


        public string MovieImage { get; set; }

        public bool IsActive { get; set; }
    }
}
