using Microsoft.AspNet.Identity.EntityFramework;

namespace TDS.Presentation.Ui.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
    }
}