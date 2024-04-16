using Mobile_Computing_Lab.Layers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mobile_Computing_Lab
{
    public partial class Skoolers : System.Web.UI.Page
    {
        SkoolersDataAccessModule db = new SkoolersDataAccessModule();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                startUp();
            }
        }

        protected void startUp()
        {
            divsOff();
            string currentUserId = (string)Session["userId"];
            if (currentUserId != null)
            {
                main.Visible = true;
            }
            else
            {
                login.Visible = true;
            }
        }

        protected void divsOff()
        {
            login.Visible =
                main.Visible =
                high_school_maintanence.Visible =
                view_school.Visible = false;
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {

            string userIdString = userId.Value;
            string passwordString = password.Value;

            DataTable resTable = db.getStudentPassword(userIdString);
            DataRow user = resTable.Rows.Count > 0 ? resTable.Rows[0] : null;
            if (user != null)
            {
                string userPassword = user["password"].ToString().Trim();
                if (String.Equals(passwordString, userPassword))
                {
                    Session["userId"] = userIdString;
                    userId.Value = password.Value = "";
                    startUp();
                }
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Remove("userId");
            startUp();
        }

        protected void high_school_maintanence_btn_Click(object sender, EventArgs e)
        {
            divsOff();
            high_school_maintanence.Visible = true;

            loadHighSchools(highschool_dropdown);
            loadStudents(student_dropdown, "-");
            initializeStudentsDropdown();
            disableHighSchoolEdit();
            disableHighSchoolAdd();
            disableStudentEdit();
        }

        public void initializeStudentsDropdown()
        {
            int school_num = int.Parse(highschool_dropdown.SelectedValue);
            DataTable highSchoolStudentDT = db.getHighSchoolHeadStudent(school_num);
            if (highSchoolStudentDT.Rows.Count == 0)
            {
                student_dropdown.SelectedIndex = 0;
            }
            else
            {
                int? headStudent = highSchoolStudentDT.Rows[0]["head student"] as int?;
                if (headStudent != null)
                {
                    int highSchoolHeadStudent = headStudent.Value;
                    student_dropdown.SelectedValue = highSchoolHeadStudent.ToString();
                }
                else
                {
                    student_dropdown.SelectedIndex = 0;
                }
            }
        }

        protected void high_school_maintanence_backBtn_Click(object sender, EventArgs e)
        {
            goHome();
        }

        protected void view_school_backBtn_Click(object sender, EventArgs e)
        {
            goHome();
        }

        protected void goHome()
        {
            divsOff();
            main.Visible = true;
        }

        protected void view_school_btn_Click(object sender, EventArgs e)
        {
            divsOff();
            view_school.Visible = true;

            loadHighSchools(view_school_dropdown);
            showHeadStudent();
        }

        void showHeadStudent()
        {
            DataTable highSchoolHeadStudent = db.getHighSchoolHeadStudent(int.Parse(view_school_dropdown.SelectedValue));
            if(highSchoolHeadStudent.Rows.Count == 0)
            {
                head_student.InnerText = "-";
            }else
            {
                DataRow studentRecord = highSchoolHeadStudent.Rows[0];
                head_student.InnerText = studentRecord["first name"] + " " + studentRecord["last name"];
            }
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            string highSchoolName = highschool_name.Value;

            try
            {
                db.createHighSchool(highSchoolName);
                loadHighSchoolMaintanenceHighschools();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    high_school_maintanence_error.Text = "High School Names Must Be Unique";
                }

            }
        }

        protected void loadHighSchools(DropDownList dropDown)
        {
            DataTable highschools = db.getHighSchools();
            dropDown.DataSource = highschools;
            dropDown.DataBind();
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            int highschoolId = int.Parse(highschool_dropdown.SelectedValue);
            string highSchoolName = highschool_name.Value;
            try
            {
                db.updateHighSchool(highschoolId, highSchoolName);
                loadHighSchoolMaintanenceHighschools();
                disableHighSchoolEdit();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    high_school_maintanence_error.Text = "High School Names Must Be Unique";
                }
            }
        }

        protected void removeBtn_Click(object sender, EventArgs e)
        {
            int highschool_num = int.Parse(highschool_dropdown.SelectedValue);
            db.removeHighSchool(highschool_num);
            loadHighSchoolMaintanenceHighschools();
        }

        protected void loadStudents(DropDownList dropDown)
        {
            dropDown.Items.Clear();
            dropDown.DataSource = db.getHighSchoolStudents();
            dropDown.DataBind();
        }

        protected void loadStudents(DropDownList dropdown, string tempOption)
        {
            loadStudents(dropdown);
            if (tempOption != null)
            {
                dropdown.Items.Insert(0, new ListItem(tempOption, null));
            }
        }

        protected void loadHighSchoolMaintanenceHighschools()
        {
            loadHighSchools(highschool_dropdown);
            high_school_maintanence_error.Text = "";
        }

        protected void studentEditBtn_Click(object sender, EventArgs e)
        {
            enableStudentEdit();
        }

        protected void studentSaveBtn_Click(object sender, EventArgs e)
        {
            int school_num = int.Parse(highschool_dropdown.SelectedValue);
            int student_num = int.Parse(student_dropdown.SelectedValue);

            try
            {
                db.setHighSchoolHeadStudent(school_num, student_num);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    high_school_maintanence_error.Text = "That Student Is already assigned to another school";
                }

            }

        }

        protected void studentCancelBtn_Click(object sender, EventArgs e)
        {
            disableStudentEdit();
        }

        void disableHighSchoolEdit()
        {
            updateBtn.Visible = cancelBtn.Visible = false;
            editBtn.Visible = true;
            highschool_name.Disabled = true;
            highschool_name.Value = "";
        }

        void enableHighSchoolEdit()
        {
            updateBtn.Visible = cancelBtn.Visible = true;
            editBtn.Visible = false;
            highschool_name.Disabled = false;
            highschool_name.Value = highschool_dropdown.SelectedItem.Text;
            highschool_name.Focus();
        }

        void enableHighSchoolAdd()
        {
            addBtn.Visible =
            cancelAddBtn.Visible = true;
            highschool_name.Disabled = false;
            newBtn.Visible = removeBtn.Visible = high_school_maintanence_backBtn.Visible = false;
        }

        void disableHighSchoolAdd()
        {
            addBtn.Visible =
            cancelAddBtn.Visible = false;
            highschool_name.Disabled = true;
  
            newBtn.Visible = removeBtn.Visible = high_school_maintanence_backBtn.Visible = true;
        }

        protected void highschool_dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            initializeStudentsDropdown();
        }

        protected void editBtn_Click(object sender, EventArgs e)
        {
            enableHighSchoolEdit();
        }

        protected void cancelBtn_Click(object sender, EventArgs e)
        {
            disableHighSchoolEdit();
        }

        protected void cancelAddBtn_Click(object sender, EventArgs e)
        {
            disableHighSchoolAdd();
        }

        protected void newBtn_Click(object sender, EventArgs e)
        {
            enableHighSchoolAdd();
        }

        void disableStudentEdit()
        {
            student_dropdown.Enabled = false;
            studentEditBtn.Visible = true;
            studentSaveBtn.Visible = false;
            studentCancelBtn.Visible = false;
        }

        void enableStudentEdit()
        {
            student_dropdown.Enabled = true;
            studentEditBtn.Visible = false;
            studentSaveBtn.Visible = true;
            studentCancelBtn.Visible = true;
        }

        protected void view_school_dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            showHeadStudent();
        }
    }
}