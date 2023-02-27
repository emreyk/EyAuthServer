using Microsoft.AspNetCore.Identity;

namespace EyAuthServer.Core.Models
{
    public class UserApp : IdentityUser
    {
        public string City { get; set; }
    }
}
