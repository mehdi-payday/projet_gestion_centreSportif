﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projet_gestion_centreSportif.Partiels {
    public partial class Panier : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {
            List<Models.Activite> list = (List<Models.Activite>) Session["panier"];
            if (list != null) {
                activites.DataSource = list;
                activites.DataBind();
            } else {

            }
        }

        protected void removeActivite(object sender, EventArgs e) {
            LinkButton btn = (LinkButton)sender;
            int idActivite = int.Parse(btn.CommandArgument.ToString());

            List<Models.Activite> panier = (List<Models.Activite>) Session["panier"];
            foreach (Models.Activite activite in panier){
                if(activite.id == idActivite) {
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
    }
}