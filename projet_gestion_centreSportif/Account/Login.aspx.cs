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
            if (!string.IsNullOrEmpty(returnUrl)) {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
            var email = Request.QueryString["email"];
            if (email != null) {
                Email.Text = email;
            }
        }

        protected void LogIn(object sender, EventArgs e) {
            MembreService membreService = new MembreService();
            Membre membre = new Membre();
            VisiteService visiteService = new VisiteService();
            Visite visite = new Visite();
            membre.Email = Email.Text;
            membre.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(Password.Text, "SHA1");
            membre = membreService.MembreValid(membre);

            if (membre != null) {
                string [] roles = new string[2] { "normal",null};
                if (membre.IsAdmin == 1) {
                    roles[1] = "admin";
                }
                visite.IdMembre = membre.IdMembre;
                visiteService.Login(visite);
                CreateTicket(membre.Nom, roles);
                HttpContext.Current.Session["userID"] = membre.IdMembre;
                HttpContext.Current.Response.Redirect("~/default.aspx");
            } else {
                FailureText.Text = "Wrong email/password, please try again!";
                FailureText.Visible = true;
            }
        }
        private void CreateTicket(string nom, string[] roles) {
            var ticket = new FormsAuthenticationTicket(
                    version: 1,
                    name: nom,
                    issueDate: DateTime.Now,
                    expiration: DateTime.Now.AddMinutes(30),
                    isPersistent: RememberMe.Checked,
                    userData: String.Join("|", roles));

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}