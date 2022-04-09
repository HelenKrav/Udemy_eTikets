using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Udemy_eTikets.Data;

namespace Udemy_eTikets.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Movie Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }

        [Display(Name ="Movie Image")]
        public string ImageURL { get; set; }


        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }


        //Cinema
        public Cinema Cinema { get; set; }
        
        [ForeignKey("CinemaId")]
        public int CinemaId { get; set; }


        //Producer
        public Producer Producer { get; set; }

        [ForeignKey("ProducerId")]
        public int ProducerId { get; set; }
    }
}
