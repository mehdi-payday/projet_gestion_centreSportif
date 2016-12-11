using System;
using System.Web.UI;
using projet_gestion_centreSportif.Models;
using System.Web.Security;
using projet_gestion_centreSportif.Services;

namespace projet_gestion_centreSportif.Account
{
    public partial class Register : Page {
        protected void CreateUser_Click(object sender, EventArgs e) {
            Membre membre = new Membre();
            membre.Prenom = First_name.Text;
            membre.Nom = Last_name.Text;
            membre.Email = Email.Text;
            membre.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(Password.Text, "SHA1");
            MembreService membreService = new MembreService();
            membreService.inscrire(membre);
            Response.Redirect("~/Account/Login.aspx?email=" + membre.Email);
            
            
        }
    }
}