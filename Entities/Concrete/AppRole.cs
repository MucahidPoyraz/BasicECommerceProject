using Microsoft.AspNetCore.Identity;

namespace Entities.Concrete
{
    public class AppRole : IdentityRole<int>
    {
        public AppRole() : base() { }

        public AppRole(string roleName) : base(roleName) { }
        public string Description { get; set; }
    }
}
