using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.BookTheShow.Models
{
    public class UserDetail
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public String Gender { get; set; }

        [Required]
        public decimal Contact { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

    }
}
