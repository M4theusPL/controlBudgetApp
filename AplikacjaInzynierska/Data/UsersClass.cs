using System.ComponentModel.DataAnnotations;

namespace AplikacjaInzynierska.Data
{
    public class UsersClass
    {
        [Key]
        public int id_user { get; set; }
        public int id_group { get; set; }
        public string admin_group { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime date_birthday { get; set; }
        public string email { get; set; }
        public string password { get; set; }

    }
}
