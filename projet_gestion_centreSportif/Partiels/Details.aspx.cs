using projet_gestion_centreSportif.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projet_gestion_centreSportif.Partiels {
    public partial class Details : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            int idActivite = -1;
            Models.Activite activite = null;
            if (Request.Params.Get("id") == null || Request.Params.Get("id") == "") {
                Response.Redirect("Activite.aspx");
            }
            else {
                if (!int.TryParse(Request.Params.Get("id"), out idActivite)) {
                    Response.Redirect("Activite.aspx");
                }
                else {
                    activite = new ActiviteService().Read(idActivite);
                    if (activite == null) {
                        Response.Redirect("Activite.aspx");
                    }
                }
            }
            if (activite.Image != null && activite.Image.Contains("~/Content/Images/")) {
                imageActivite.ImageUrl = activite.Image;
            }
            else {
                imageActivite.Visible = false;
            }
            lblNom.Text = activite.Nom;
            lblDescription.Text = activite.Description;
            lblDuree.Text = activite.Duree.ToString();
            lblPrix.Text = activite.Prix.ToString();
        }

        protected void btnInscrire_Click(object sender, EventArgs e) {
            int idActivite=-1;
            string id = Request.Params.Get("id");
            if (int.TryParse(id, out idActivite)) {
                addActivite(idActivite);
            }
            Response.Redirect("Activite.aspx");
        }

        protected bool hasActivite(int idActivite) {
            return activiteInPanier(idActivite) || activiteInInscription(idActivite);
        }

        protected bool activiteInPanier(int idActivite) {
            List<Models.Activite> panier = (List<Models.Activite>) HttpContext.Current.Session["panier"];
            if (panier != null) {
                foreach (Models.Activite activite in panier) {
                    if (activite.id == idActivite) {
                        return true;
                    }
                }
            }
            return false;
        }

        protected bool activiteInInscription(int idActivite) {
            String idMembre = (String) HttpContext.Current.Session["userID"];
            List<Models.Inscription> activiteInscrit = new InscriptionService().FindByMembre(int.Parse(idMembre));
            if (activiteInscrit != null) {
                foreach (Models.Inscription inscription in activiteInscrit) {
                    if (int.Parse(inscription.IdActivite) == idActivite) {
                        return true;
                    }
                }
            }
            return false;
        }

        protected void addActivite(int idActivite) {
            List<Models.Activite> panier = (List<Models.Activite>) HttpContext.Current.Session["panier"];
            if (panier == null) {
                panier = new List<Models.Activite>();
            }
            if (activiteInPanier(idActivite)) {
                Session.Add("errorMsg", "Vous avez déjà l'activité dans votre panier");
            }
            else if (activiteInInscription(idActivite)) {
                Session.Add("errorMsg", "Vous êtes déjà inscrit à cette activité");
            }
            else {
                panier.Add(new ActiviteService().Read(idActivite));
                Session.Add("activiteAdded", panier[panier.Count - 1].Nom);
            }
            HttpContext.Current.Session["panier"] = panier;
        }
    }
}