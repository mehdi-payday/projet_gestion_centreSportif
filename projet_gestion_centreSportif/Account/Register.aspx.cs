using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Security;
using projet_gestion_centreSportif.Models;
using projet_gestion_centreSportif.Services;

namespace projet_gestion_centreSportif.Account
{
    public partial class Register : Page
    {
        /*protected void CreateUser_Click(object sender, EventArgs e) {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
        */
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