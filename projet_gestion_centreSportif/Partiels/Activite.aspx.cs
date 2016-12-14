using Microsoft.AspNet.Identity;
using projet_gestion_centreSportif.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projet_gestion_centreSportif.Partiels {
    public partial class Activite : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            var msg = Session["errorMsg"];
            if (msg != null) {
                Session["errorMsg"] = null;
                error.Text = msg.ToString();
                errorPanel.Visible = true;
            }
            msg = Session["activiteAdded"];
            if (msg != null) {
                Session["activiteAdded"] = null;
                activiteAddedLabel.Text = msg.ToString();
                activiteAddedPanel.Visible = true;
            }
            if (!IsPostBack && Request.IsAuthenticated) {
                if (HttpContext.Current.Session["userID"] == null) {
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/Account/Login.aspx");
                }
            }
        }

        protected void btnInscription_Click(object sender, EventArgs e) {
            LinkButton btn = (LinkButton)sender;
            int idActivite = int.Parse(btn.CommandArgument.ToString());
            addActivite(idActivite);
            Server.TransferRequest(Request.Url.AbsolutePath, false);
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

        protected void seeDetails(object sender, EventArgs e) {
            LinkButton btn = (LinkButton)sender;
            int idActivite = int.Parse(btn.CommandArgument.ToString());
            Response.Redirect("Details.aspx?id=" + idActivite);
        }

        protected void activites_DataBound(object sender, EventArgs e) {
            if (Context.User.IsInRole("admin")) {
                GridView gridview = (GridView)sender;
                gridview.Columns[0].Visible = false;
            }
        }
    }
}