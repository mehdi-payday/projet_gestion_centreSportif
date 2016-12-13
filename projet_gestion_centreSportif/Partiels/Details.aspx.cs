using projet_gestion_centreSportif.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projet_gestion_centreSportif.Partiels {
    public partial class Details : System.Web.UI.Page {

        private string id;

        protected void Page_Load(object sender, EventArgs e) {
            id = Request.Params.Get("id");
            int idActivite;
            if(int.TryParse(id,out idActivite)) {
                Models.Activite activite = new ActiviteService().Read(idActivite);
                if (activite != null) {
                    if (activite.Image != null && activite.Image.Contains("~/Content/Images/")) {
                        imageActivite.ImageUrl = activite.Image;
                    }
                    else {
                        imageActivite.Visible = false;
                    }
                }
            }
        }

        protected void btnInscrire_Click(object sender, EventArgs e) {
            int idActivite=-1;
            if (int.TryParse(id, out idActivite)) {
                //Response.Redirect("Activite.aspx?inscriptId=" + idActivite);
                addActivite(idActivite);
            }
            Response.Redirect("Activite.aspx");
        }

        protected bool hasActivite(int idActivite) {
            List<Models.Activite> panier = (List<Models.Activite>)HttpContext.Current.Session["panier"];
            if (panier != null) {
                foreach (Models.Activite activite in panier) {
                    if (activite.id == idActivite) {
                        return true;
                    }
                }
            }
            String idMembre = (String)HttpContext.Current.Session["userID"];
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
                    Session.Add("activiteAdded", panier[panier.Count - 1].Nom);
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
            HttpContext.Current.Session["panier"] = panier;
            //Server.TransferRequest(Request.Url.AbsolutePath, false);
        }
    }
}