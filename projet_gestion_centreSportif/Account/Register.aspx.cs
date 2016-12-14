using System;
using System.Web.UI;
using projet_gestion_centreSportif.Models;
using System.Web.Security;
using projet_gestion_centreSportif.Services;

namespace projet_gestion_centreSportif.Account
{
    public partial class Register : Page {

        protected void Page_Load(object sender, EventArgs e) {
            if (User.Identity.IsAuthenticated) {
                Response.Redirect("~/Default");
            }
        }
        protected void CreateUser_Click(object sender, EventArgs e) {
            MembreService membreService = new MembreService();
            Membre membre = new Membre();
            membre.Prenom = First_name.Text;
            membre.Nom = Last_name.Text;
            membre.Email = Email.Text;
            membre.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(Password.Text, "SHA1");
            if (membreService.EmailUnique(membre)) {
                membreService.inscrire(membre);
                Response.Redirect("~/Account/Login.aspx?email=" + membre.Email);
            } else {
                ErrorMessage.Text = "L'adresse courriel utilisée appartient déjà à un utilisateur.";
                ErrorMessage.Visible = true;
            }
            
        }
    }
}