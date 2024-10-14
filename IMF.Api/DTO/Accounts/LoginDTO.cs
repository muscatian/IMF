using System.ComponentModel.DataAnnotations;

namespace IMF.Api.DTO.Accounts
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required] 
        public string Password { get; set; }
    }
}
