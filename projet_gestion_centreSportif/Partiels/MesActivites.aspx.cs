using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projet_gestion_centreSportif.Partiels {
    public partial class MesActivites : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            string userID = (string) HttpContext.Current.Session["userID"];
            MySQL.SelectParameters.Add("ID", userID);
        }

        protected void seeDetails(object sender, EventArgs e) {
            LinkButton btn = (LinkButton)sender;
            int idActivite = int.Parse(btn.CommandArgument.ToString());
            Response.Redirect("Details.aspx?id=" + idActivite);
        }
    }
}