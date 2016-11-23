﻿using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using projet_gestion_centreSportif.Models;
using projet_gestion_centreSportif.Services;
using System.Web.Security;
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
            User user = new User();
            user.Email = Email.Text;
            user.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(Password.Text, "SHA1");
            UserService userService = new UserService();

            if (userService.ValidUser(user)) {
                FormsAuthentication.SetAuthCookie(Email.Text, RememberMe.Checked);
                FormsAuthentication.RedirectFromLoginPage(Email.Text, RememberMe.Checked);
            }
            else{
                FailureText.Text = "Wrong credentions, try again!";
            }
        }        
    }
}