using System;
using System.Collections.Generic;

#nullable disable

namespace Nagarro.BookTheShow.DAL.EFModels
{
    public partial class UserMovieBook
    {
        public int Id { get; set; }
        public int? MovieSlotId { get; set; }
        public string SeatNos { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public int NoOfTickets { get; set; }
        public DateTime BookingDate { get; set; }
        public int? Rating { get; set; }

        public virtual User User { get; set; }
    }
}
