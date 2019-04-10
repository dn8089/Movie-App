namespace MovieWebApi.Migrations
{
    using MovieWebApi.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieWebApi.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovieWebApi.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Directors.AddOrUpdate(
                    new Director() { Id = 1, Name = "Steven", Lastname = "Spielberg", Age = 72},
                    new Director() { Id = 2, Name = "Kathryn", Lastname = "Bigelow", Age = 67},
                    new Director() { Id = 3, Name = "Martin", Lastname = "Scorsese", Age = 76},
                    new Director() { Id = 4, Name = "Quentin", Lastname = "Tarantino", Age = 56}
                );

            context.Movies.AddOrUpdate(
                    new Movie() { Id = 1, Name = "Jaws", Genre = "Drama/Mystery", Year = 1975, DirectorId = 1},
                    new Movie() { Id = 2, Name = "Jurassic Park", Genre = "Drama/Mystery", Year = 1993, DirectorId = 1},
                    new Movie() { Id = 3, Name = "Ready Player One", Genre = "Thriller/Fantasy", Year = 2018, DirectorId = 1},
                    new Movie() { Id = 4, Name = "Zero Dark Thirty", Genre = "Thriller/Drama", Year = 2012, DirectorId = 2},
                    new Movie() { Id = 5, Name = "Detroit", Genre = "Drama/Crime", Year = 2017, DirectorId = 2},
                    new Movie() { Id = 6, Name = "Taxi Driver", Genre = "Mystery/Crime", Year = 1976, DirectorId = 3},
                    new Movie() { Id = 7, Name = "Goodfellas", Genre = "Drama/Crime", Year = 1990, DirectorId = 3},
                    new Movie() { Id = 8, Name = "The Irishman", Genre = "Drama/Crime", Year = 2019, DirectorId = 3},
                    new Movie() { Id = 9, Name = "Kill Bill: Volume 1", Genre = "Mystery/Crime", Year = 2003, DirectorId = 4},
                    new Movie() { Id = 10, Name = "Django Unchained", Genre = "Drama/Blaxploitation", Year = 2012, DirectorId = 4}
                );
        }
    }
}
