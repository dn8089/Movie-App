using MovieWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieWebApi.Interface
{
    public interface IDirectorRepository
    {
        IEnumerable<Director> GetAll();
        Director GetById(int id);
        void Add(Director director);
        void Update(Director director);
        void Delete(Director director);
    }
}
