using System.ComponentModel.DataAnnotations;

namespace AplikacjaInzynierska.Data
{
    public class LoginPageClass
    {
        [Key]
        public string email { get; set; }
        public string password { get; set; }
    }
}
