using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using statements that are requiored to connect to EF(Entity FrameWork) DB
using COMP229_F2017_Lesson6.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

namespace COMP229_F2017_Lesson6
{
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* If loading the Page for the first time 
             * Populate the Student grid view
             */
            if (!IsPostBack)
            {
                Session["SortColumn"] = "StudentID";//default short column
                Session["SortDirection"] = "ASC";
                // Get the Student Data
                this.GetStudents();
            }
        }
        /// <summary>
        /// This method gets the Students data from the DB
        /// </summary>
        private void GetStudents()
        {
            // Connect  to Entity FrameWork DB
            using (ControlsoContext db = new ControlsoContext())
            {
                string SortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                //Query the Students Table using EF and LINQ
                var Students = (from allStudents in db.Students
                                select allStudents);
                // bind the result to the Student GridView
                //StudentGridView.DataSource = Students.ToList();
                StudentGridView.DataSource = Students.AsQueryable().OrderBy(SortString).ToList();
                StudentGridView.DataBind();
            }
        }

        protected void StudentGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            // Store which row is clicked
            int selectedRow = e.RowIndex;

            //get the selected StudentId using the Grid's DataKey collection
            int StudentID = Convert.ToInt32(StudentGridView.DataKeys[selectedRow].Values["StudentID"]);

            //use EF and LINQ to find selected student in the DB and remove it
            using (ControlsoContext db = new ControlsoContext())
            {
                // Create object to the student class and store the query inside of it 
                Student deleteStudent = (from studentRecords in db.Students
                                         where studentRecords.StudentID == StudentID
                                         select studentRecords).FirstOrDefault();
                //remove the selected student from the db
                db.Students.Remove(deleteStudent);

                //Save my changes back to the db
                db.SaveChanges();

                //refresh the Grid
                this.GetStudents();
            }

        }

        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Set new Page Size
            //StudentGridView.PageSize = Convert.ToInt32(PageDropDownList);

        }

        protected void StudentGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            //get the column to sort by
            Session["SortColumn"] = e.SortExpression;

            //Refresh the Grid View
            this.GetStudents();

            // toggle the deriction
            Session["SortDirection"] = Session["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }

        protected void StudentGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header)//if header row has been clicked
                {
                    LinkButton linkbutton = new LinkButton();
                    for (int index = 0; index < StudentGridView.Columns.Count -1; index++)
                    {
                        if (StudentGridView.Columns[index].SortExpression == Session["SortColumn"].ToString())
                        {
                            if (Session["SortDirection"].ToString() == "ASC")
                            {
                                linkbutton.Text = "<i class='fa fa-caret-up fa-lg'></i>";
                            }
                            else
                            {
                                linkbutton.Text = "<i class='fa fa-caret-down fa-lg'></i>";
                            }

                            e.Row.Cells[index].Controls.Add(linkbutton);
                        }

                    }

                }
            }
        }

        protected void StudentGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the new page number
            StudentGridView.PageIndex = e.NewPageIndex;

            //Refresh the Gried view
            this.GetStudents();
        }

        protected void PageSizeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Set new Page Size
            StudentGridView.PageSize = Convert.ToInt32(PageSizeDropDownList.SelectedValue);

            //refresh the gridview
            this.GetStudents();
        }
    }
}