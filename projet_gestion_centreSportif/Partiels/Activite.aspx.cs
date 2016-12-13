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
                //if (Request["inscriptId"] != null) {
                //    int idActivite = -1;
                //    if (int.TryParse(Request["inscriptId"], out idActivite)) {
                //        addActivite(idActivite);
                //    }
                //}
            }
            if (Context.User.IsInRole("admin")) {
            }
        }

        protected void btnInscription_Click(object sender, EventArgs e) {
            LinkButton btn = (LinkButton) sender;
            int idActivite = int.Parse(btn.CommandArgument.ToString());
            addActivite(idActivite);
        }

        protected void addActivite(int idActivite) {
            List<Models.Activite> panier = (List<Models.Activite>) HttpContext.Current.Session["panier"];
            if(panier == null) {
                panier = new List<Models.Activite>();
            }
            bool dejaAjoute = false;
            foreach (Models.Activite activite in panier) {
                if (activite.id == idActivite) {
                    dejaAjoute = true;
                    break;
                }
            }
            if (!dejaAjoute) {
                String idMembre = (String) HttpContext.Current.Session["userID"];
                List<Models.Inscription> activiteInscrit = new InscriptionService().FindByMembre(int.Parse(idMembre));
                if (activiteInscrit != null) {
                    foreach (Models.Inscription inscription in activiteInscrit) {
                        if (int.Parse(inscription.IdActivite) == idActivite) {
                            dejaAjoute = true;
                            break;
                        }
                    }
                }
                if (!dejaAjoute) {
                    panier.Add(new ActiviteService().Read(idActivite));
                    Session.Add("activiteAdded", panier[panier.Count-1].Nom);
                }
                else {
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "errMessage1", "alert(\"Vous êtes déjà inscrit à cette activité\");", true);
                    Session.Add("errorMsg", "Vous êtes déjà inscrit à cette activité");
                }
            }
            else {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "errMessage2", "alert(\"Vous avez déjà l'activité dans votre panier\");", true);
                Session.Add("errorMsg", "Vous avez déjà l'activité dans votre panier");
            }
            HttpContext.Current.Session["panier"]=panier;
            Server.TransferRequest(Request.Url.AbsolutePath, false);
        }

        protected void seeDetails(object sender, EventArgs e) {
            LinkButton btn = (LinkButton) sender;
            int idActivite = int.Parse(btn.CommandArgument.ToString());
            Response.Redirect("Details.aspx?id="+idActivite);
        }
    }
}