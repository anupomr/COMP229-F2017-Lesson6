using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// required for Identity and OWIN Security
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace COMP229_F2017_Lesson6
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            //Create new userStore and userManeger objects;
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            //serch for and create a new user Object
            var user = userManager.Find(UserNameTextBox.Text, PasswordTextBox.Text);

            //if a match  is found for the user
            if(user != null )
            {
                //authenticate and login our user
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                //sign in the user
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);

                //redirect the user to the main menu
                Response.Redirect("~/Contoso/MainManu.aspx");
            }
            else //user is not found
            {
                StatusLabel.Text = "Invalid Username or Password";
                AlertFlash.Visible = true;
            }

        }
    }
}