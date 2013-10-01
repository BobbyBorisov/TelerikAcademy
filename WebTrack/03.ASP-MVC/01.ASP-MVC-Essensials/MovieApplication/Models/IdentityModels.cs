using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace MovieApplication.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : User
    {  
    }

    public class MovieDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public DbSet<Movie> Movies { set; get; }
        public DbSet<Genre> Genres { set; get; }
    }
}