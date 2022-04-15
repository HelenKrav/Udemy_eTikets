using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Udemy_eTikets.Data.Base;

namespace Udemy_eTikets.Models
{
    public class Cinema: IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Cinema Logo")]
        [Required(ErrorMessage = "Cinema Logo is required")]
        public string Logo { get; set; }

        [Display(Name ="Cinema Name")]
        [Required(ErrorMessage = "Cinema Name is required")]
        [StringLength(100, MinimumLength =3,ErrorMessage = "Cinema Name must be [3:100] chars")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        //Relationships
        public List<Movie> Movies { get; set; }
    }
}
