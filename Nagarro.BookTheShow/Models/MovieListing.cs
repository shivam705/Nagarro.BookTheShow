using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.BookTheShow.Models
{
    public class MovieListing
    {
        public int Id { get; set; }

        [Required]
        public string MovieName { get; set; }

        [Required]
        public string MovieDescription { get; set; }


        public string MovieImage { get; set; }

        /*[Display(Name = "Start Time")]
        
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm }", ApplyFormatInEditMode = true)]*/
        public DateTime? MovieTime { get; set; }

        [Required]
        public decimal Fare { get; set; }

        /*[Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]*/
        public DateTime? MovieDate { get; set; }

        [Required]
        public int MaxSeats { get; set; }

        [Required]
        public int AvailableSeats { get; set; }

        public bool IsActive { get; set; }
    }
}
