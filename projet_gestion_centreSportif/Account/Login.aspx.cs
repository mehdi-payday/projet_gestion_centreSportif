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
            if (!string.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e) {
            Membre membre = new Membre();
            membre.Email = Email.Text;
            membre.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(Password.Text, "SHA1");
            MembreService membreService = new MembreService();
            membre = membreService.MembreValid(membre);
            if (membre != null) {
                string [] roles = new string[2] { "normal",null};
                if (membre.IsAdmin == 1) {
                    roles[1] = "admin";
                }
                CreateTicket(membre.Nom, roles);
                HttpContext.Current.Response.Redirect("~/default.aspx");
            } else {
                FailureText.Text = "Wrong email/password, please try again!";
                FailureText.Visible = true;
            }
        }
        private void CreateTicket(string name, string[] roles) {
            var ticket = new FormsAuthenticationTicket(
                    version: 1,
                    name: name,
                    issueDate: DateTime.Now,
                    expiration: DateTime.Now.AddMinutes(30),
                    isPersistent: false,
                    userData: String.Join("|", roles));

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}