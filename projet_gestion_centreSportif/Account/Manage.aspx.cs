using System;
using System.Web;
using projet_gestion_centreSportif.Models;
using projet_gestion_centreSportif.Services;
using System.Web.Security;

namespace projet_gestion_centreSportif.Account
{
    public partial class Manage : System.Web.UI.Page {
        MembreService membreService;
        protected string userID { get; set; }

        protected void Page_Load() {
            membreService = new MembreService();
            if (HttpContext.Current.Session["userID"] == null) {
                FormsAuthentication.SignOut();
                Response.Redirect("~/Account/Login.aspx");
            }
            userID = (string)HttpContext.Current.Session["userID"];
            MySQL.SelectCommand = "SELECT m.prenom, m.nom, m.email, v.date, v.ipAdresse FROM visite v, membre m WHERE v.idMembre= m.id AND v.idMembre=" + userID + " ORDER BY date DESC";
        }

        protected void ChangeInfo(object sender, EventArgs e) {
            Membre membre = membreService.Read(userID);
            if (this.newPrenom.Text != null && this.newPrenom.Text != "") {
                string newPrenom = this.newPrenom.Text;
                membre.Prenom = newPrenom;
            }
            if (this.newNom.Text != null && this.newNom.Text != "") {
                string newNom = this.newNom.Text;
                membre.Nom = newNom;
            }

            membreService.Update(membre);
            change_info_message.Text = "Vos informations ont été mis à jour. L'affichage va être mis à jour après votre prochaine connexion.";
            change_info_message.Visible = true;
        }
        protected void ChangePassword(object sender, EventArgs e) {
            Membre membre = membreService.Read(userID);
            string newPassword1 = this.newPassword1.Text;
            string newPassword2 = this.newPassword2.Text;
            string inputCurrentPasswordHashed = FormsAuthentication.HashPasswordForStoringInConfigFile(currentPassword.Text, "SHA1");
            if (inputCurrentPasswordHashed != membre.Password) {
                current_password_error.Text = "Mot de passe actuel erroné";
                current_password_error.Visible = true;
            } else {
                membre.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(newPassword1, "SHA1");
                membreService.Update(membre);
                changePassowrd_message.Text = "Mot de passe mis à jour";
                current_password_error.Visible = false;
                changePassowrd_message.Visible = true;
            }
        }
    }
}