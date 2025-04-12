using System;
using System.Collections.Generic;

#nullable disable

namespace Nagarro.BookTheShow.DAL.EFModels
{
    public partial class MovieListing
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        public string MovieImage { get; set; }
        public DateTime? MovieTime { get; set; }
        public decimal Fare { get; set; }
        public DateTime? MovieDate { get; set; }
        public int MaxSeats { get; set; }
        public int AvailableSeats { get; set; }
    }
}
