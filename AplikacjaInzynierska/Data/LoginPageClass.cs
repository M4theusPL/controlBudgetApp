using System.ComponentModel.DataAnnotations;

namespace AplikacjaInzynierska.Data
{
    public class LoginPageClass
    {
        [Key]
        public string email { get; set; }
        public string password { get; set; }
        public string admin_group { get; set; }
    }
}
