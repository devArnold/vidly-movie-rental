using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public enum Genre
    {
        Romance,
        Action,
        Comedy,
        Family,
        Thriller
    }


    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }

        [Display(Name = "Number in stock")]
        public int NumberInStock { get; set; }


        
        [Display(Name = "Release Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Data added")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateAdded { get; set; }

        public Movie()
        {
            DateAdded = DateTime.Now.Date;
        }


    }
}