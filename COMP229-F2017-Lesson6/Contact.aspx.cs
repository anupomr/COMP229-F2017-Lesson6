using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COMP229_F2017_Lesson6
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("First Name: " + FirstNameTextBox.Text);
            Debug.WriteLine("Last Name: " + LastNameTextBox.Text);
            Debug.WriteLine("Email: " + EmailTextBox.Text);
            Debug.WriteLine("Contact Number: " + ContactNumberTextBox.Text);
        }
    }
}