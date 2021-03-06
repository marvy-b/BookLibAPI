using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibAPI.Models
{
    public class User
    {
        [Key]
        public string UserId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string GivenName { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
