using Microsoft.AspNetCore.Identity;

namespace Entities.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string FullName { get; set; }

        // Navigation Properties
        public ICollection<Order> Orders { get; set; }
    }
}
