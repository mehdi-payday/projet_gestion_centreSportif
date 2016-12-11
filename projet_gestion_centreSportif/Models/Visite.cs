using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projet_gestion_centreSportif.Models {
    public class Visite {
        public string IdVisite{ get; set; }
        public string IdMembre{ get; set; }
        public DateTime Date { get; set; }
    }
}