using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// using statements required  for EF Db access
using COMP229_F2017_Lesson6.Models;
using System.Web.ModelBinding;


namespace COMP229_F2017_Lesson6
{
    public partial class StudentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            //Redirect back to the student page
            Response.Redirect("~/Contoso/Students.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            //use EF to conect to the server
            using (ControlsoContext db = new ControlsoContext())
            {
                //use the student model to create a new students object and
                // save a new record
                Student newStudent = new Student();

                int StudentID = 0;

                if (Request.QueryString.Count > 0)//our URL has a StudentID in it
                {
                    // get the id from the URL
                }
                // add form data th the  new student record
                newStudent.LastName = LastNameTextBox.Text;
                newStudent.FirstMidName = FirstNameTextbox.Text;
                newStudent.EnrollmentDate = Convert.ToDateTime(EnrollmentDateTextbox.Text);

                //use  LINQ to ADO.NET to add / insert students into the db
                if (StudentID == 0)
                {
                    db.Students.Add(newStudent);
                }

                //save our changes -also updates and inserts
                db.SaveChanges();

                // Redirect back to the update Students page
                Response.Redirect("~/Contoso/Students.aspx");
            }
        }
    }
}