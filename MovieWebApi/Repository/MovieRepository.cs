using MovieWebApi.Interface;
using MovieWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MovieWebApi.Repository
{
    public class MovieRepository : IDisposable, IMovieRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<Movie> GetAll()
        {
            return db.Movies.Include(m => m.Director);
        }

        public Movie GetById(int id)
        {
            return db.Movies.Include(m => m.Director).FirstOrDefault(m => m.Id == id);
        }

        public void Add(Movie movie)
        {
            db.Movies.Add(movie);
            db.SaveChanges();
        }

        public void Update(Movie movie)
        {
            db.Entry(movie).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch(DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(Movie movie)
        {
            db.Movies.Remove(movie);
            db.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if(disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}