using System.ComponentModel.DataAnnotations;

namespace AplikacjaInzynierska.Data
{
    public class GroupClass
    {
        [Key]
        public int id_group { get; set; }
        public string name_group { get; set; }
    }
}
