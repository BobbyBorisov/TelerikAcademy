using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace LibrarySystemMvc.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : User
    {  
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, UserClaim, UserSecret, UserLogin, Role, UserRole, Token, UserManagement>
    {
       
        public DbSet<Book> Books { set; get; }

        public DbSet<Category> Categories { set; get; }

        public DbSet<Author> Authors { set; get; }

    }
}