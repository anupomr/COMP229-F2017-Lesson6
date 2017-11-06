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
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetStudent();
            }
        }

        protected void GetStudent()
        {
            //populated the form with existing data from db
            int StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);
            //Connect to the EF DB
            using (ControlsoContext db = new ControlsoContext())
            {
                // populate a student object  instance with the studentID
                // from the url parameter
                Student updateStudent = (from student in db.Students
                                         where student.StudentID == StudentID
                                         select student).FirstOrDefault();
                // map the student properties to the form control
                if(updateStudent != null)
                {
                    LastNameTextBox.Text = updateStudent.LastName;
                    FirstNameTextbox.Text = updateStudent.FirstMidName;
                    EnrollmentDateTextbox.Text = updateStudent.EnrollmentDate.ToString("yyyy-MM-dd");

                }


            }
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
                    StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);
                    //get the Current  student  from EF bd
                    newStudent = (from student in db.Students
                                  where student.StudentID == StudentID
                                  select student).FirstOrDefault();
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