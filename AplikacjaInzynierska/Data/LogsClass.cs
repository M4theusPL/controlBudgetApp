using System.ComponentModel.DataAnnotations;

namespace AplikacjaInzynierska.Data
{
    public class LogsClass
    {
        [Key]
        public int id_log { get; set; }
        public DateTime date { get; set; }
        public TimeOnly time { get; set; }
        public int id_user { get; set; }
        public string event_log { get; set; }
    }
}
