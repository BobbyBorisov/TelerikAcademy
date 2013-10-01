namespace MovieApplication.Migrations
{
    using MovieApplication.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieApplication.Models.MovieDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MovieApplication.Models.MovieDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
      //      var adminRole = new Microsoft.AspNet.Identity.EntityFramework.Role()
      //      {
      //          Name = "Admin"

      //      };
      //      context.Roles.Add(adminRole);

      //      var allGenre = new Genre() { Name = "All" };
      //      var comedyGenre = new Genre() { Name = "Comedy" };
      //      var actionGenre = new Genre() { Name = "Action" };
      //      context.Genres.AddOrUpdate(allGenre);
      //      context.Genres.AddOrUpdate(actionGenre);
      //      context.Genres.AddOrUpdate(comedyGenre);



      //      var adminUser = new ApplicationUser()
      //      {
      //          UserName = "admin",
      //          Roles = new List<Microsoft.AspNet.Identity.EntityFramework.UserRole>()
      //      };

      //      context.Users.AddOrUpdate(adminUser);
      //      //context.SaveChanges();


      //      adminUser.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.UserRole()
      //      {

      //          Role = adminRole,
      //          UserId = adminUser.Id
      //      });



      //      var logins = new Microsoft.AspNet.Identity.EntityFramework.UserLogin()
      //      {
      //          LoginProvider = "Local",
      //          ProviderKey = adminUser.UserName,
      //          UserId = adminUser.Id
      //      };

      //      var list = new List<Microsoft.AspNet.Identity.EntityFramework.UserLogin>() { logins };
      //      adminUser.Logins = list;


      //      // context.SaveChanges();
      //      context.UserSecrets.AddOrUpdate(new Microsoft.AspNet.Identity.EntityFramework.UserSecret()
      //      {
      //          Secret = "AI+y+rXkPiP9UEW7kYgYnvnVut4gBexTIQiouk880cIlMqmxaw71HH6m5DPHr1Gz4A==",
      //          UserName = adminUser.UserName

      //      });
      //      // context.SaveChanges();


      //      context.Movies.AddOrUpdate(i => i.Title,
      //  new Movie
      //  {
      //      Title = "When Harry Met Sally",
      //      ReleaseDate = DateTime.Parse("1989-1-11"),
      //      Genre = comedyGenre,
      //      Rating = RatingType.A,
      //      Price = 7.99M
      //  },

      //   new Movie
      //   {
      //       Title = "Ghostbusters ",
      //       ReleaseDate = DateTime.Parse("1984-3-13"),
      //       Genre = comedyGenre,
      //       Rating = RatingType.B,
      //       Price = 8.99M
      //   },

      //   new Movie
      //   {
      //       Title = "Ghostbusters 2",
      //       ReleaseDate = DateTime.Parse("1986-2-23"),
      //       Genre = comedyGenre,
      //       Rating = RatingType.A,
      //       Price = 9.99M
      //   },

      // new Movie
      // {
      //     Title = "Rio Bravo",
      //     ReleaseDate = DateTime.Parse("1959-4-15"),
      //     Genre = actionGenre,
      //     Rating = RatingType.A,
      //     Price = 3.99M
      // }
      //);
        }
    }
}
