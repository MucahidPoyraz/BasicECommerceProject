using Microsoft.AspNetCore.Identity;

namespace Entities.Concrete
{
    public class AppRole : IdentityRole<int>
    {
        public string Description { get; set; }
    }
}
