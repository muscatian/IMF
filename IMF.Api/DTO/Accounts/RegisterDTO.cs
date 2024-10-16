﻿using System.ComponentModel.DataAnnotations;

namespace IMF.Api.DTO.Accounts
{
    public class RegisterDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required] 
        public string LastName { get; set; }
        [Required] 
        public string Email { get; set; }
        [Required] 
        public string Password { get; set; }
        public string[] Roles { get; set; }
    }
}
