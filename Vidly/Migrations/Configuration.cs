namespace Vidly.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Vidly.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Vidly.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Vidly.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var membershipTypes = new List<MembershipType>
            {
                new MembershipType{Id= 1,SignUpFee= 0,DurationInMonths= 0,DiscountRate=0 ,Name= "Pay as You Go"},
                new MembershipType{Id= 2,SignUpFee= 30,DurationInMonths= 1,DiscountRate= 10, Name = "Monthly"},
                new MembershipType{Id= 3,SignUpFee= 90,DurationInMonths= 3,DiscountRate= 15, Name= "Quarterly"},
                new MembershipType{Id= 4,SignUpFee= 300,DurationInMonths= 12,DiscountRate= 20, Name= "Annual"}
            };

            membershipTypes.ForEach(s => context.MembershipTypes.AddOrUpdate(p => p.Id,s));
            context.SaveChanges();

            context.Customers.AddOrUpdate(x => x.Id,
                new Customer { Id = 1, Name = "John Smith", IsSubscribedToNewsletter = false, MembershipTypeId = 1, BirthDate = DateTime.Parse("1990-12-08") },
                new Customer { Id = 2, Name = "Mary Williams", IsSubscribedToNewsletter = true, MembershipTypeId = 2 , BirthDate = DateTime.Parse("2000-09-05") });

            context.Movies.AddOrUpdate(x => x.Id,
                new Movie { Id = 1,Name = "The Hangover", Genre = "Comedy", DateAdded = DateTime.Parse("2010-09-06"), ReleaseDate = DateTime.Parse("2010-08-06"), NumberInStock = 5},
                new Movie { Id = 2, Name = "Die Hard", Genre = "Action", DateAdded = DateTime.Parse("2018-09-06"), ReleaseDate = DateTime.Parse("2018-09-04"), NumberInStock = 6},
                new Movie { Id = 3, Name = "The Terminator", Genre = "Action", DateAdded = DateTime.Parse("2015-09-06"), ReleaseDate = DateTime.Parse("2010-09-06"), NumberInStock = 4},
                new Movie { Id = 4, Name = "Toy Story", Genre = "Family", DateAdded = DateTime.Parse("2011-09-06"), ReleaseDate = DateTime.Parse("2011-07-06"), NumberInStock =3},
                new Movie { Id = 5, Name = "Titanic", Genre = Genre.Romance.ToString(), DateAdded = DateTime.Parse("2017-09-06"), ReleaseDate = DateTime.Parse("2017-05-06"), NumberInStock =4 }
                );
        }


    }
}
