using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Mobile_Computing_Lab
{
    public partial class modules : System.Web.UI.Page
    {
        DataAcessModules dbAccess = new DataAcessModules();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                startUp();
            }
        }

        void startUp()
        {
            StudentDropdown.DataSource = dbAccess.getAllStudents();
            StudentDropdown.DataBind();
            showStudentInfo();
            refreshModules();
            refreshStudentsDoingModule();

            divsOff();
            main.Visible = true;
        }

        void refreshModules()
        {
            ModuleDropdown.DataSource = dbAccess.getModules(int.Parse(StudentDropdown.SelectedValue));
            ModuleDropdown.DataBind();
            showModuleInfo();
        }

        void refreshStudentsDoingModule()
        {
            if (ModuleDropdown.Items.Count == 0) return;
            ModuleStudentsDropdown.DataSource = dbAccess.getStudentsDoingModule(int.Parse(ModuleDropdown.SelectedValue));
            ModuleStudentsDropdown.DataBind(); ;
        }

        protected void ModuleDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            showModuleInfo();
        }

        protected void StudentDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            showStudentInfo();
            refreshModules();
        }

        void showStudentInfo()
        {
            formsOff();
            if (gridviewstudents_selected_num.Text == string.Empty) return;

            student_fname.Text = student_lname.Text = string.Empty;

            if (StudentDropdown.Items.Count == 0) return;

            DataTable db = dbAccess.getSingleStudent(int.Parse(StudentDropdown.SelectedValue));

            student_fname.Text = db.Rows[0]["first name"].ToString();
            student_lname.Text = db.Rows[0]["last name"].ToString();
        }

        void showModuleInfo()
        {
            faculty_college_owner.Text =
                lecturer.Text =
                lecturer_email.Text = string.Empty;

            if (ModuleDropdown.Items.Count == 0) return;

            DataTable db = dbAccess.getSingleModule(int.Parse(ModuleDropdown.SelectedValue));

            lecturer.Text = db.Rows[0]["lecturer"].ToString();
            lecturer_email.Text = db.Rows[0]["lecturer email"].ToString();
            faculty_college_owner.Text = db.Rows[0]["fc name"].ToString();
        }

        void studentMaintanenceFormOff()
        {
            student_maintanence_firstname_txt_bx.Enabled
                = student_maintanence_lastname_txt_bx.Enabled
                = student_maintanence_add.Enabled
                = student_maintanence_update.Enabled = false;
        }

        void refreshStudentMaintanenceStudents()
        {
            formsOff();
            DataTable students = dbAccess.getAllStudents();
            students_gridview.Columns[2].Visible = true;
            students_gridview.DataSource = students;
            students_gridview.DataBind();
            students_gridview.Columns[2].Visible = false;

            students_maintanence_dropdown.DataSource = students;
            students_maintanence_dropdown.DataBind();
            showStudent();
        }
        void formsOff()
        {
            studentMaintanenceFormOff();
        }

        void divsOff()
        {
            main.Visible = student_maintanence.Visible = module_maintanence.Visible = module_info.Visible = false;
        }

        void clearMessages()
        {
            student_maintanence_feedback.Text = string.Empty;
        }

        void showStudentsDoingModul()
        {

        }

        protected void ModuleStudenstDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshStudentsDoingModule();
        }

        protected void module_info_back_btn_Click(object sender, EventArgs e)
        {
            divsOff();
            main.Visible = true;
        }

        protected void module_info_btn_Click(object sender, EventArgs e)
        {
            divsOff();
            module_info.Visible = true;
        }

        protected void student_maintanence_btn_Click(object sender, EventArgs e)
        {
            divsOff();
            student_maintanence.Visible = true;
            clearMessages();
            refreshStudentMaintanenceStudents();
        }

        void showStudent()
        {
            int studentId = int.Parse(students_maintanence_dropdown.SelectedValue.ToString());
            DataTable students = dbAccess.getSingleStudent(studentId);
            DataRow student = students.Rows[0];
            student_maintanence_firstname_txt_bx.Text = student["first name"].ToString();
            student_maintanence_lastname_txt_bx.Text = student["last name"].ToString();
        }

        protected void student_maintanence_go_back_Click(object sender, EventArgs e)
        {
            divsOff();
            main.Visible = true;
        }

        protected void students_maintanence_dropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            showStudent();
        }

        protected void student_maintanence_edit_btn_Click(object sender, EventArgs e)
        {
            formsOff();
            clearMessages();

            student_maintanence_firstname_txt_bx.Enabled =
                student_maintanence_lastname_txt_bx.Enabled =
                student_maintanence_update.Enabled = true;
        }

        protected void student_maintanence_update_Click(object sender, EventArgs e)
        {
            clearMessages();
            if (string.IsNullOrEmpty(student_maintanence_firstname_txt_bx.Text))
            {
                student_maintanence_feedback.Text = "First Name Required";
                return;
            }
            if (string.IsNullOrEmpty(student_maintanence_lastname_txt_bx.Text))
            {
                student_maintanence_feedback.Text = "Last Name Required";
                return;
            }
            int student_num = int.Parse(gridviewstudents_selected_num.Text);
            string fname = student_maintanence_firstname_txt_bx.Text;
            string lname = student_maintanence_lastname_txt_bx.Text;
            dbAccess.updateStudent(student_num, fname, lname);
            student_maintanence_feedback.Text = "Updated";
        }

        protected void student_maintanence_new_Click(object sender, EventArgs e)
        {
            clearMessages();
            formsOff();
            student_maintanence_firstname_txt_bx.Enabled =
                student_maintanence_lastname_txt_bx.Enabled =
                student_maintanence_add.Enabled = true;

            student_maintanence_firstname_txt_bx.Text = student_maintanence_lastname_txt_bx.Text = string.Empty;
        }

        protected void student_maintanence_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(student_maintanence_firstname_txt_bx.Text))
            {
                student_maintanence_feedback.Text = "First Name Required";
                return;
            }
            if (string.IsNullOrEmpty(student_maintanence_lastname_txt_bx.Text))
            {
                student_maintanence_feedback.Text = "Last Name Required";
                return;
            }
            string fname = student_maintanence_firstname_txt_bx.Text;
            string lname = student_maintanence_lastname_txt_bx.Text;

            dbAccess.addStudent(fname, lname);
            refreshStudentMaintanenceStudents();
            student_maintanence_feedback.Text = "done";
        }

        protected void module_maintanence_btn_Click(object sender, EventArgs e)
        {
            divsOff();
            module_maintanence.Visible = true;
            //clearMessages();
            //refreshStudentMaintanenceStudents();
        }

        protected void module_maintanence_new_Click(object sender, EventArgs e)
        {

        }

        protected void module_maintanence_add_Click(object sender, EventArgs e) { }
        protected void module_maintanence_update_Click(object sender, EventArgs e) { }
        protected void module_maintanence_go_back_Click(object sender, EventArgs e)
        {
            divsOff();
            main.Visible = true;
        }

        protected void students_select_Click(object sender, EventArgs e)
        {
            int rw = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            gridviewstudents_selected_num.Text = students_gridview.Rows[rw].Cells[2].Text;
            for (int i = 0; i < students_gridview.Rows.Count; i++)
            {
                students_gridview.Rows[i].BackColor = System.Drawing.Color.White;
            }
            students_gridview.Rows[rw].BackColor = System.Drawing.Color.LightGreen;
            showStudentInfo();
        }

        protected void students_edit_Click(object sender, EventArgs e)
        {
            formsOff();
            clearMessages();

            int rw = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            gridviewstudents_selected_num.Text = students_gridview.Rows[rw].Cells[2].Text;

            showStudent();

            student_maintanence_firstname_txt_bx.Enabled =
                student_maintanence_lastname_txt_bx.Enabled =
                student_maintanence_update.Enabled = true;

            student_maintanence_firstname_txt_bx.BackColor =
                student_maintanence_lastname_txt_bx.BackColor = System.Drawing.Color.LightYellow;
        }
    }
}