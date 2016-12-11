using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using projet_gestion_centreSportif.Models;
using projet_gestion_centreSportif.Services;
using System.Web.Security;

namespace projet_gestion_centreSportif.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected string SuccessMessage
        {
            get;
            private set;
        }
        MembreService membreService;
        protected string userID { get; set; }

        protected void Page_Load() {
            membreService = new MembreService();
            if (HttpContext.Current.Session["userID"] == null) {
                FormsAuthentication.SignOut();
                Response.Redirect("~/Account/Login.aspx");
            }
            userID = (string)HttpContext.Current.Session["userID"];
            MySQL.SelectCommand = "SELECT m.prenom, m.nom, m.email, v.date FROM visite v, membre m WHERE v.idMembre= m.id AND v.idMembre=" + userID;
        }
        
        protected void ChangeInfo(object sender, EventArgs e) {
            Membre membre = membreService.Read(userID);
            if (this.newPrenom.Text != null && this.newPrenom.Text !="") {
                string newPrenom = this.newPrenom.Text;
                membre.Prenom = newPrenom;
            }
            if (this.newNom.Text != null && this.newNom.Text !="") {
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
            } else if (newPassword1 != newPassword2) {
                new_password_error.Text = "Les mots de passe ne correspondent pas";
                new_password_error.Visible = true;
            } else {
                membre.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(newPassword1, "SHA1");
                new_password_error.Visible = false;
                current_password_error.Visible = false;
                changePassowrd_message.Text = "Mot de passe mis à jour";
                changePassowrd_message.Visible = true;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        // Remove phonenumber from user
        protected void RemovePhone_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var result = manager.SetPhoneNumber(User.Identity.GetUserId(), null);
            if (!result.Succeeded)
            {
                return;
            }
            var user = manager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                Response.Redirect("/Account/Manage?m=RemovePhoneNumberSuccess");
            }
        }

        // DisableTwoFactorAuthentication
        protected void TwoFactorDisable_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.SetTwoFactorEnabled(User.Identity.GetUserId(), false);

            Response.Redirect("/Account/Manage");
        }

        //EnableTwoFactorAuthentication 
        protected void TwoFactorEnable_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            manager.SetTwoFactorEnabled(User.Identity.GetUserId(), true);

            Response.Redirect("/Account/Manage");
        }
    }
}