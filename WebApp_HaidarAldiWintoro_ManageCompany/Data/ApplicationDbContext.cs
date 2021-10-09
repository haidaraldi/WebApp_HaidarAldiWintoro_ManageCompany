using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp_HaidarAldiWintoro_ManageCompany.Models;

namespace WebApp_HaidarAldiWintoro_ManageCompany.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Companies> Companies { get; set; }
        public DbSet<Employees> Employees { get; set; }
    }
}
