using projet_gestion_centreSportif.Services;
using System;
using System.Collections.Generic;

namespace projet_gestion_centreSportif.Admin.activite {
    public partial class WebForm1 : System.Web.UI.Page {

        ActiviteService activiteService;
        protected List<Models.Activite> activites;

        protected void Page_Load(object sender, EventArgs e) {
            activiteService = new ActiviteService();
            activites = getActivites();
        }

        private List<Models.Activite> getActivites() {
            return this.activiteService.GetAll();
        }

        private Models.Activite getMembre(int idActivite) {
            return this.activiteService.Read(idActivite);
        }
    }
}