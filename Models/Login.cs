using System.ComponentModel.DataAnnotations;


namespace Zamawianie_biletow.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Pole Login jest wymagana!")]
        public string UserLogin { get; set; }
        [Required(ErrorMessage = "Pole Password jest wymagana!")]
        public string Password { get; set; }    
    }
}
