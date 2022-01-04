using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibAPI.Models
{
    public class UserConstants
    {
        public static List<User> Users = new List<User>()
        {
            new User() { Username = "marvy_admin", EmailAddress = "marvelous.admin@email.com", Password = "Marvy_220", GivenName = "Marvelous", Surname = "Oyediji", Role = "Administrator" },
            new User() { Username = "tochi_all", EmailAddress = "tochi.all@email.com", Password = "Marvy_220", GivenName = "Tochi", Surname = "Idris", Role = "General" },
        };
    }
}
