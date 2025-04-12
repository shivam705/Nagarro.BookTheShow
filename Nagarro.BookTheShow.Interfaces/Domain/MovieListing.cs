using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookTheShow.Interfaces.Domain
{
   public class MovieListing
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
        public bool IsActive { get; set; }
    }
}
