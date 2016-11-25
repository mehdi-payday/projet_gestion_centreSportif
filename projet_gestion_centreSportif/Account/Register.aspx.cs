using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using projet_gestion_centreSportif.Models;
using System.Web.Security;
using projet_gestion_centreSportif.Services;

namespace projet_gestion_centreSportif.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e) {
            Membre membre = new Membre();
            membre.Prenom = First_name.Text;
            membre.Nom = Last_name.Text;
            membre.Email = Email.Text;
            membre.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(Password.Text, "SHA1");
            MembreService membreService = new MembreService();
            if (membreService.inscrire(membre)) {
                FormsAuthentication.SetAuthCookie(Email.Text, false);
                FormsAuthentication.RedirectFromLoginPage(Email.Text, false);
            } else {
                ErrorMessage.Text = "Failed to register user, try again!";
            }
        }
    }
}