namespace LibrarySystemMvc.Migrations
{
    using LibrarySystemMvc.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<LibrarySystemMvc.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LibrarySystemMvc.Models.ApplicationDbContext context)
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
            //context.Authors.AddOrUpdate(i => i.Name,
            //    new Author()
            //    {
            //        Name = "Nakov"
            //    },
            //    new Author()
            //    {
            //        Name = "Niki"
            //    },
            //    new Author()
            //    {
            //        Name = "Doncho"
            //    });

            //context.Categories.AddOrUpdate(i=>i.Name,
            //    new Category()
            //    {
            //        Name = "Programing"
            //    },
            //    new Category()
            //    {
            //        Name = "Science"
            //    });

            //context.Books.AddOrUpdate(i => i.Title,
            //    new Book()
            //    {
            //        Title = "Programming",
            //        Description = "Description of programing book",
            //        WebSite = "www.programing.com",
            //        CategoryId = 1,
            //        AuthorId = 1,
            //        ISBN = "102303"
            //    },
            //    new Book()
            //    {
            //        Title = "Databases book",
            //        Description = "Description of databases book",
            //        WebSite = "www.databases.com",
            //        CategoryId = 2,
            //        AuthorId = 2,
            //        ISBN = "3133155"
            //    },
            //    new Book()
            //    {
            //        Title = "Algorithms",
            //        Description = "Algorithms book description",
            //        WebSite = "www.algorithms.com",
            //        CategoryId = 1,
            //        AuthorId = 3,
            //        ISBN = "512412"
            //    }
            //    );
        }
    }
}
