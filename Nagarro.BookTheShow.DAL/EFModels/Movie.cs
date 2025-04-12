using System;
using System.Collections.Generic;

#nullable disable

namespace Nagarro.BookTheShow.DAL.EFModels
{
    public partial class Movie
    {
        public Movie()
        {
            MovieSlots = new HashSet<MovieSlot>();
        }

        public int Id { get; set; }
        public string MovieName { get; set; }
        public string MovieDescription { get; set; }
        public string MovieImage { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<MovieSlot> MovieSlots { get; set; }
    }
}
