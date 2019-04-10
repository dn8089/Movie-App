using MovieWebApi.Interface;
using MovieWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieWebApi.Controllers
{
    public class MoviesController : ApiController
    {
        IMovieRepository _repository;

        public MoviesController(IMovieRepository repository)
        {
            _repository = repository;
        }

        // GET api/movies
        public IEnumerable<Movie> Get()
        {
            return _repository.GetAll();
        }

        // GET api/movies/1
        public IHttpActionResult Get(int id)
        {
            var movie = _repository.GetById(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // POST api/movies
        public IHttpActionResult Post(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(movie);
            return CreatedAtRoute("DefaultApi", new { id = movie.Id }, movie);
        }

        // PUT api/movies/1
        public IHttpActionResult Put(int id, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movie.Id)
            {
                return BadRequest();
            }

            try
            {
                _repository.Update(movie);
            }
            catch
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // DELETE api/movies/1
        public IHttpActionResult Delete(int id)
        {
            var movie = _repository.GetById(id);

            if (movie == null)
            {
                return NotFound();
            }

            _repository.Delete(movie);
            return Ok();
        }
    }
}
