using Microsoft.AspNetCore.Identity;

namespace B_Rock.Data
{
    public class B_RockUser : IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }
        [PersonalData]
        public string LastName { get; set; }
    }
}
