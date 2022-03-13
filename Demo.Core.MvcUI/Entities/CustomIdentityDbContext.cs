using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo.Core.MvcUI.Entities
{
    public class CustomIdentityDbContext:IdentityDbContext<CustomIdentityUser,CustomIdentityRole, string> 
    {
        public CustomIdentityDbContext(DbContextOptions<CustomIdentityDbContext>options):base(options)
        {

        }
    }
}
