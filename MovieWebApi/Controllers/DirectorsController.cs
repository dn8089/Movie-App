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
    public class DirectorsController : ApiController
    {
        IDirectorRepository _repository { get; set; }

        public DirectorsController(IDirectorRepository repository)
        {
            _repository = repository;
        }

        // GET api/directors
        public IEnumerable<Director> Get()
        {
            return _repository.GetAll();
        }

        // GET api/directors/1
        public IHttpActionResult Get(int id)
        {
            Director director = _repository.GetById(id);

            if (director == null)
            {
                return NotFound();
            }

            return Ok(director);
        }

        // POST api/directors
        public IHttpActionResult Post(Director director)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(director);
            return CreatedAtRoute("DefaultApi", new { id = director.Id }, director);
        }

        // PUT api/directors/1
        public IHttpActionResult Put(int id, Director director)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != director.Id)
            {
                return BadRequest();
            }

            try
            {
                _repository.Update(director);
            }
            catch
            {
                return NotFound();
            }

            return Ok(director);
        }

        // DELETE api/directors/1
        public IHttpActionResult Delete(int id)
        {
            var director = _repository.GetById(id);

            if (director == null)
            {
                return NotFound();
            }

            _repository.Delete(director);
            return Ok();
        }
    }
}
