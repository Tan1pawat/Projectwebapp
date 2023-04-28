using Microsoft.EntityFrameworkCore;
using Projectwebapp.Models;

namespace Projectwebapp.Data
{
    public class ApplicationDBcontext:DbContext
    {
        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext>options) :base(options)
        {
        }
        public DbSet<User> Users { get; set; }

    }
}
