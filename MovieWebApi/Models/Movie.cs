using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieWebApi.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Genre { get; set; }
        [Required]
        [Range(1800, Int32.MaxValue)]
        public int Year { get; set; }

        //Navigation property
        public Director Director { get; set; }
        //Foreign Key
        public int DirectorId { get; set; }
    }
}