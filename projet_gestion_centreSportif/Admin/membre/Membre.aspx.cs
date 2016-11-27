using System;
using System.Collections.Generic;
using projet_gestion_centreSportif.Services;

namespace projet_gestion_centreSportif.Admin.membre {
    public partial class Membre : System.Web.UI.Page {

        MembreService membreService;
        protected List<Models.Membre> membres;

        protected void Page_Load(object sender, EventArgs e) {
            membreService = new MembreService();
            this.membres = getMembres();
        }

        private List<Models.Membre> getMembres() {
            return this.membreService.GetAll();
        }

        private Models.Membre getMembre(int idMembre) {
            return this.membreService.Read(idMembre);
        }
    }
}