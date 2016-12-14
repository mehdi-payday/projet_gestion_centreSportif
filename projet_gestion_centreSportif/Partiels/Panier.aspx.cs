using projet_gestion_centreSportif.Models;
using projet_gestion_centreSportif.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projet_gestion_centreSportif.Partiels {
    public partial class Panier : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            List<Models.Activite> list = (List<Models.Activite>)Session["panier"];
            if (list != null && list.Count != 0) {
                activites.DataSource = list;
                activites.DataBind();
            } else {
                checkoutBouton.Visible = false;
                panierVide.Visible = true;
            }
        }

        protected void removeActivite(object sender, EventArgs e) {
            LinkButton btn = (LinkButton)sender;
            int idActivite = int.Parse(btn.CommandArgument.ToString());

            List<Models.Activite> panier = (List<Models.Activite>)Session["panier"];
            foreach (Models.Activite activite in panier) {
                if (activite.id == idActivite) {
                    panier.Remove(activite);
                    break;
                }
            }
            Session["panier"] = panier;
            Server.TransferRequest(Request.Url.AbsolutePath, false);
        }

        protected void seeDetails(object sender, EventArgs e) {
            LinkButton btn = (LinkButton)sender;
            int idActivite = int.Parse(btn.CommandArgument.ToString());
            Response.Redirect("Details.aspx?id=" + idActivite);
        }

        protected void toggleCheckout(object sender, EventArgs e) {
            checkoutPanel.Visible = checkoutPanel.Visible ? false : true;
        }

        protected void payerActivites(object sender, EventArgs e) {
            InscriptionService inscriptionService = new InscriptionService();
            MembreService membreService = new MembreService();
            string idMembre = (string) HttpContext.Current.Session["userID"];
            Membre membre = membreService.Read(idMembre);
            DateTime dateDebut = DateTime.Now;

            List<Models.Activite> panier = (List<Models.Activite>)Session["panier"];
            foreach(Models.Activite activite in panier) {
                DateTime dateFin = dateDebut.AddDays(activite.Duree);
                Inscription inscriptionModel = new Inscription();
                inscriptionModel.IdActivite = activite.id.ToString();
                inscriptionModel.IdMembre = idMembre;
                inscriptionModel.DateInscription = dateDebut;
                inscriptionModel.DateFin = dateFin;
                inscriptionService.Add(inscriptionModel);
            }
            membre.Adresse = adresseField.Text;
            membre.Cart_Credit = noCarteField.Text;
            membre.Cart_CVC = cvcField.Text;
            membreService.Update(membre);

            Session["panier"] = null;
            Response.Redirect("Confirmation.aspx");
        }
    }
}
