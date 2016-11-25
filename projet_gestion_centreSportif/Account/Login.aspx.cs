using System;
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
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e) {
            Membre membre = new Membre();
            membre.Email = Email.Text;
            membre.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(Password.Text, "SHA1");
            MembreService membreService = new MembreService();

            if (membreService.MembreValid(membre)) {
                FormsAuthentication.SetAuthCookie(Email.Text, RememberMe.Checked);
                FormsAuthentication.RedirectFromLoginPage(Email.Text, RememberMe.Checked);
            } else {
                FailureText.Text = "Wrong email/password, please try again!";
                FailureText.Visible = true;
            }

        }
    }
}