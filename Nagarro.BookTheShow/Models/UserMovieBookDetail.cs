using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.BookTheShow.Models
{
    public class UserMovieBookDetail
    {
        public int Id { get; set; }

        [Required]
        public int? MovieSlotId { get; set; }

        [Required]
        public string SeatNos { get; set; }

       // [Required]
        public int UserId { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        [Range(0, 10)]
        public int NoOfTickets { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public int? Rating { get; set; }
    }
}
