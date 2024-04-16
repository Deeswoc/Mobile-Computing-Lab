using Mobile_Computing_Lab.Layers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mobile_Computing_Lab
{
    public partial class Staffmembers : System.Web.UI.Page
    {
        StaffMembersDataAccessModule db = new StaffMembersDataAccessModule();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                startUp();
            }
        }

        void startUp()
        {
            loadDepartmentsDropdown();
            StaffMemberDropDown.Enabled = false;
            PastTraveledCountriesDropdown.Enabled = false;
        }

        void loadDepartmentsDropdown()
        {
            DepartmentDropdown.Items.Clear();
            DepartmentDropdown.Enabled = true;
            DataTable departments = db.getDepartments();
            DepartmentDropdown.DataSource = departments;
            DepartmentDropdown.DataBind();
            DepartmentDropdown.Items.Insert(0, "Select a Department");
        }

        void loadStaffDropDown(int department_num)
        {
            StaffMemberDropDown.Items.Clear();
            DataTable staff = db.getDepartmentStaff(department_num);
            if (staff.Rows.Count == 0)
            {
                disableStaffDropdown();
            }
            else
            {
                StaffMemberDropDown.Enabled = true;
                StaffMemberDropDown.DataSource = staff;
                StaffMemberDropDown.DataBind();
                StaffMemberDropDown.Items.Insert(0, "Select Staff Member");
            }
        }

        void loadTravelledCountriesDropDown(int member_num)
        {
            PastTraveledCountriesDropdown.Items.Clear();
            DataTable countries = db.getStaffPastCountries(member_num);
            if (countries.Rows.Count == 0)
            {
                PastTraveledCountriesDropdown.Enabled = false;
            }
            else
            {
                PastTraveledCountriesDropdown.Enabled = true;
                PastTraveledCountriesDropdown.DataSource = countries;
                PastTraveledCountriesDropdown.DataBind();
            }
        }

        void disableForm()
        {
            DepartmentDropdown.Enabled = false;
            DepartmentDropdown.Items.Clear();
            disableStaffDropdown();
            unloadStaffInfo();
        }

        void loadStaffInfo(int member_num)
        {
            DataRow staff = db.getStaffDetails(member_num).Rows[0];
            MemberContactNumber.Text = staff["contact no"].ToString();
            MemberAddress.Text = staff["full address"].ToString();
        }

        void unloadStaffInfo()
        {
            MemberContactNumber.Text  = 
            MemberAddress.Text = "-";
        }

        void disableStaffDropdown()
        {
            StaffMemberDropDown.Items.Clear();
            StaffMemberDropDown.Enabled = false;
            disablePastTraveledCountriesDropdown();
        }

        void disablePastTraveledCountriesDropdown()
        {
            PastTraveledCountriesDropdown.Items.Clear();
            PastTraveledCountriesDropdown.Enabled = false;
        }

        protected void TurnOffCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (TurnOffCheckBox.Checked)
            {
                disableForm();
            }
            else { startUp(); }
        }

        protected void PastTraveledCountriesDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void StaffMemberDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StaffMemberDropDown.SelectedIndex != 0)
            {
                int member_num = int.Parse(StaffMemberDropDown.SelectedValue);
                loadStaffInfo(member_num);
                loadTravelledCountriesDropDown(member_num);
            }
            else
            {
                unloadStaffInfo();
                disablePastTraveledCountriesDropdown();
            }
        }

        protected void DepartmentDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DepartmentDropdown.SelectedIndex != 0)
            {
                int department_num = int.Parse(DepartmentDropdown.SelectedValue);
                loadStaffDropDown(department_num);
            }
            else
            {
                disableStaffDropdown();
            }
        }
    }
}