using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookTheShow.Interfaces.Domain
{
    public class MovieSlot
    {
        public int Id { get; set; }
        public int? MovieId { get; set; }
        public DateTime? MovieTime { get; set; }
        public decimal Fare { get; set; }
        public DateTime MovieDate { get; set; }
        public int MaxSeats { get; set; }
        public int AvailableSeats { get; set; }
    }
}
