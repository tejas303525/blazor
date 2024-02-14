using System;
using System.ComponentModel.DataAnnotations;

namespace proj1.Shared
{
    [Serializable]
    public class UserHardcodedAccount
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }

    }


}