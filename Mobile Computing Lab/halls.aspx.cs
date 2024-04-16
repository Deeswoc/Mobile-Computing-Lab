using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mobile_Computing_Lab
{
    public partial class halls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CheckBox_student_CheckedChanged(object sender, EventArgs e)
        {
            enableFormActions();
        }

        protected void Button_reset_Click(object sender, EventArgs e)
        {
            CheckBox_isAthlete.Checked = false;
            CheckBox_student.Checked = false;
            CheckBox_isAthlete.Enabled = false;
            DropDownList_hall.Enabled = false;
            populateHallsList(null);

        }

        enum StudentStatus
        {
            Student,
            Athlete
        }



        void enableFormActions()
        {
            if (CheckBox_student.Checked)
            {
                CheckBox_isAthlete.Enabled = true;
                CheckBox_isAthlete.Checked = false;
                DropDownList_hall.Enabled = true;
                populateHallsList(StudentStatus.Student);
            }
            else
            {
                CheckBox_isAthlete.Enabled = false;
                DropDownList_hall.Enabled = false;
                populateHallsList(null);
            }
        }

        protected void CheckBox_isAthlete_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox_isAthlete.Checked)
            {
                populateHallsList(StudentStatus.Athlete);   
            }
            else
            {
                populateHallsList(StudentStatus.Student);
            }
        }

        void populateHallsList(StudentStatus? status)
        {
            DropDownList hallsList = DropDownList_hall;
            hallsList.Items.Clear();

            switch (status)
            {
                case null:
                    {
                        break;
                    }
                case StudentStatus.Student:
                    {
                        hallsList.Items.Add("Peter's");
                        hallsList.Items.Add("Jaban");
                        hallsList.Items.Add("Manning");
                        hallsList.Items.Add("Alfred Sangster");
                        break;
                    }

                case StudentStatus.Athlete:
                    {
                        hallsList.Items.Add("Jaban");
                        hallsList.Items.Add("Manning");
                        break;
                    }
            }
        }
    }
}