using System;
using System.Collections.Generic;
using projet_gestion_centreSportif.Services;

namespace projet_gestion_centreSportif.Admin.membre {
    public partial class Membre : System.Web.UI.Page {

        MembreService membreService;
        protected List<Models.Membre> membres;

        protected void Page_Load(object sender, EventArgs e) {
            membreService = new MembreService();
            this.membres = getMembers();
        }

        private List<Models.Membre> getMembers() {
            return this.membreService.GetAll();
        }
    }
}