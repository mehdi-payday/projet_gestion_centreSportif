using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projet_gestion_centreSportif.Models {
    public class Inscription {

        public string IdInscription { get; set; }
        public string IdActivite { get; set; }
        public string IdMembre { get; set; }
        public string Prix { get; set; }
        public DateTime DateInscription { get; set; }
        public DateTime DateFin { get; set; }
    }
}