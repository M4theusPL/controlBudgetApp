﻿using Microsoft.AspNetCore.Identity;

namespace AplikacjaInzynierska.Pages
{
    public class UserAccount
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
