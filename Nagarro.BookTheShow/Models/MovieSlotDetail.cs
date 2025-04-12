using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.BookTheShow.Models
{
    public class MovieSlotDetail
    {
        public int Id { get; set; }

        [Required]
        public int? MovieId { get; set; }

        [Display(Name = "Start Time")]
        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm }", ApplyFormatInEditMode = true)]
        public DateTime? MovieTime { get; set; }

        [Required]
        public decimal Fare { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime MovieDate { get; set; }

        [Required]
        public int MaxSeats { get; set; }

        [Required]
        public int AvailableSeats { get; set; }
    }
}
