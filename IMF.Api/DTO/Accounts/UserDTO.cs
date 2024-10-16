using System.Collections.Generic;
using System.Data;

namespace IMF.Api.DTO.Accounts
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Jwt { get; set; }
        public IList<string> Roles { get; set; }
    }
}
