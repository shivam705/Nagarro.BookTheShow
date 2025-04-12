using System;
using System.Collections.Generic;

#nullable disable

namespace Nagarro.BookTheShow.DAL.EFModels
{
    public partial class User
    {
        public User()
        {
            UserMovieBooks = new HashSet<UserMovieBook>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public decimal Contact { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<UserMovieBook> UserMovieBooks { get; set; }
    }
}
