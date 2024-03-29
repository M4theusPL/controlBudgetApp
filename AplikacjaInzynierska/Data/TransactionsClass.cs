﻿using System.ComponentModel.DataAnnotations;

namespace AplikacjaInzynierska.Data
{
    public class TransactionsClass
    {
        [Key]
        public int id_user_transaction { get; set; }
        public int id_user { get; set; }
        public string name_transaction { get; set; }
        public string description { get; set; }
        public double amount { get; set; }
        public DateTime date_transaction { get; set; }
        public string type_transaction { get; set; }
        public int id_group { get; set; }
    }
}