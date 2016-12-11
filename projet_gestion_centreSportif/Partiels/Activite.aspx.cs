using projet_gestion_centreSportif.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projet_gestion_centreSportif.Partiels {
    public partial class Activite : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (HttpContext.Current.Session["userID"] == null) {
                    Response.Redirect("~/Account/Login.aspx");
                }
            }
        }

        protected void addActivite(object sender, EventArgs e) {
            LinkButton btn = (LinkButton) sender;
            int idActivite = int.Parse(btn.CommandArgument.ToString());
            //this.Request.Params.Add("id",idActivite.ToString());
            //this.Response.Redirect("~/Partiels/Inscription.aspx?id="+idActivite);

            List<Models.Activite> panier = (List<Models.Activite>) HttpContext.Current.Session["panier"];
            if(panier == null) {
                panier = new List<Models.Activite>();
            }
            bool dejaAjoute = false;
            foreach (Models.Activite activite in panier) {
                if (int.Parse(activite.id) == idActivite) {
                    dejaAjoute = true;
                    break;
                }
            }
            if (!dejaAjoute) {
                String idMembre = (String) HttpContext.Current.Session["userID"];
                //Models.Membre membreCourant = new MembreService().Read((int) Context.Session["userID"]);
                //Models.Membre membreCourant = (Models.Membre) Session["userID"];
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
                }
                else {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "errMessage1", "alert(\"Vous êtes déjà inscrit à cette activité\");", true);
                }
            }
            else {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "errMessage2", "alert(\"Vous avez déjà l'activité dans votre panier\");", true);
            }
            HttpContext.Current.Session["panier"]=panier;
        }

    }
}