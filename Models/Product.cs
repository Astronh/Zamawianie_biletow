using System.ComponentModel.DataAnnotations;

namespace Zamawianie_biletow.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? UserLogin { get; set; }
        [Required(ErrorMessage = "Imię jest wymagane!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Nazwisko jest wymagane!")]
        public string UserSurname { get; set; }
        [Required]
        public int Normal { get; set; }
        [Required]
        public int Reduced { get; set; }

        
    }

    public class LoginName
    {
        public static string? LoginName1 { get; set; }
    }
}
