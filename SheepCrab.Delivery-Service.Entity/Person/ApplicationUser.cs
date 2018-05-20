

namespace Entity
{
    public class ApplicationUser : Microsoft.AspNetCore.Identity.IdentityUser
    {
        public Person Person { get; set; }
        
    }
}
