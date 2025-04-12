using System;
using System.Collections.Generic;

#nullable disable

namespace Nagarro.BookTheShow.DAL.EFModels
{
    public partial class MovieSlot
    {
        public int Id { get; set; }
        public int? MovieId { get; set; }
        public DateTime? MovieTime { get; set; }
        public decimal Fare { get; set; }
        public DateTime MovieDate { get; set; }
        public int MaxSeats { get; set; }
        public int AvailableSeats { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
