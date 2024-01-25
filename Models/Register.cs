using System.ComponentModel.DataAnnotations;

namespace Zamawianie_biletow.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Pole Login jest wymagana!")]
        public string UserLogin { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Pole Email jest wymagana!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Pole Password jest wymagana!")]
        public string Password { get; set; }
    }
}
