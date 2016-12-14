namespace projet_gestion_centreSportif.Models {
    public class Membre {

        public string IdMembre { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public int IsAdmin { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Adresse { get; set; }
        public long  Cart_Credit{ get; set; }
        public int  Cart_CVC{ get; set; }

}
}
