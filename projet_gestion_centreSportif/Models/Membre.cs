using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projet_gestion_centreSportif.Models
{
    public class Membre {
        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public int IsAdmin { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}