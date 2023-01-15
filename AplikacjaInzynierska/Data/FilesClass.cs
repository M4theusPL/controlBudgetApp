using System.ComponentModel.DataAnnotations;

namespace AplikacjaInzynierska.Data
{
    public class FilesClass
    {
        [Key]
        public int id_file { get; set; }
        public int id_user { get; set; }
        public int id_user_transaction { get; set; }
        public string filename { get; set; }
        public long filesize { get; set; }
        public byte[] attachment { get; set; }
    }
}
