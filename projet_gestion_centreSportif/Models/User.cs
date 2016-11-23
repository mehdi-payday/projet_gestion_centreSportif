using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projet_gestion_centreSportif.Models
{
    public class User {
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public int IsAdmin { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}