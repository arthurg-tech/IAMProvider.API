using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IamProvider.API.Data
{
    public class IamDbContext : IdentityDbContext<IdentityUser>
    {
        public IamDbContext(DbContextOptions<IamDbContext> options) : base(options) { }
    }
}