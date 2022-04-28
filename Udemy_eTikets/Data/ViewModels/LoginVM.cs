using System.ComponentModel.DataAnnotations;

namespace Udemy_eTikets.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name ="Email address")]
        [Required(ErrorMessage ="Email address is required")]
        public string EmailAddress { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "The Password field is required")]
        public string Password { get; set; }
    }
}
