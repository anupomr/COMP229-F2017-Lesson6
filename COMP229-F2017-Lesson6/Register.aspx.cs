using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//required for the Identity and OWIN Security
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace COMP229_F2017_Lesson6
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // redirect back to the Default page
            Response.Redirect("~/Default.aspx");
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            //Create new userStore and userManeger objects;
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            //Creat a new user object 
            var user = new IdentityUser()
            {
                UserName = UserNameTextBox.Text,
                PhoneNumber=PhoneNumberTextBox.Text,
                Email=EmailTextBox.Text
            };

            // create a new user in the database and store the results
            IdentityResult result = userManager.Create(user, PasswordTextBox.Text);

            // check if successfully registered?
            if (result.Succeeded)
            {
                //authenticate and login our new user
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                //Sign in user
                authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);

                // Redirect  to the main Maenu Page
                Response.Redirect("~/Contoso/MainManu.aspx");
            }
            else
            {
                //display error in AlertFlash div
                StatusLabel.Text = result.Errors.FirstOrDefault();
                AlertFlash.Visible = true;
            }
        }
    }
}