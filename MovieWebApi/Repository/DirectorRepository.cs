using MovieWebApi.Interface;
using MovieWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace MovieWebApi.Repository
{
    public class DirectorRepository : IDisposable, IDirectorRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<Director> GetAll()
        {
            return db.Directors;
        }

        public Director GetById(int id)
        {
            return db.Directors.FirstOrDefault(d => d.Id == id);
        }

        public void Add(Director director)
        {
            db.Directors.Add(director);
            db.SaveChanges();
        }

        public void Update(Director director)
        {
            db.Entry(director).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public void Delete(Director director)
        {
            db.Directors.Remove(director);
            db.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
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