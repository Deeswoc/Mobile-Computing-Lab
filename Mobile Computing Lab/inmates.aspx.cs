using Mobile_Computing_Lab.Layers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mobile_Computing_Lab
{
    public partial class inmates : System.Web.UI.Page
    {
        InmatesDataAccessModule dbAccess = new InmatesDataAccessModule();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                startUp();
            }
        }
        void startUp()
        {
            enableNewInmateForm();
            refreshBlocks();
        }

        void refreshBlocks()
        {
            DataTable blocks = dbAccess.getBlocks();
            blocks_gridview.Columns[0].Visible = true;
            blocks_gridview.DataSource = blocks;
            blocks_gridview.DataBind();
            blocks_gridview.Columns[0].Visible = false;
        }

        protected void students_select_Click(object sender, EventArgs e)
        {

        }

        protected void new_inmate_btn_Click(object sender, EventArgs e)
        {

        }

        protected void view_blocks_Click(object sender, EventArgs e)
        {

        }

        void enableNewInmateForm()
        {
            DataTable block = dbAccess.getBlocks();
            DataTable convictions = dbAccess.getOffenses();

            new_inmate_block_dropdown.DataSource = filterGender(new_inmate_male_checkbox.Checked, block);
            new_inmate_block_dropdown.DataBind();
            new_inmate_offense_dropdown.DataSource = convictions;
            new_inmate_offense_dropdown.DataBind();

        }

        DataTable filterGender(bool male, DataTable block)
        {
            DataTable filteredTable = block.Clone();
            string filter;
            if (male)
            {
                filter = "male = 1";
            }else
            {
                filter = "male = 0";
            }
            DataRow[] filteredRows = block.Select(filter);

            foreach (DataRow row in filteredRows)
            {
                filteredTable.ImportRow(row);
            }
            return filteredTable;
        }

        void showBlockInmates(int block_num)
        {
            DataTable inmates = dbAccess.getInmatesInBlock(block_num);
            inmates_gridview.Columns[0].Visible = true;
            inmates_gridview.DataSource = inmates;
            inmates_gridview.DataBind();
            inmates_gridview.Columns[0].Visible = false;

        }

        void loadInmate(int inmateNum)
        {
            DataRow inmate = dbAccess.getInmate(inmateNum).Rows[0];

            firstname_info.Text = inmate["first name"].ToString();
            lastname_info.Text = inmate["last name"].ToString();
            offence_commited_info.Text = inmate["offence name"].ToString();
            year_incarcerated_info.Text = inmate["year incarcerated"].ToString();
            release_year_info.Text = inmate["year due for release"].ToString();
        }

        protected void block_select_Click(object sender, EventArgs e)
        {
            int rw = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            gridviewblocks_selected_num.Text = blocks_gridview.Rows[rw].Cells[0].Text;
            for (int i = 0; i < blocks_gridview.Rows.Count; i++)
            {
                blocks_gridview.Rows[i].BackColor = System.Drawing.Color.White;
            }
            blocks_gridview.Rows[rw].BackColor = System.Drawing.Color.LightGreen;
            int block_num = int.Parse(blocks_gridview.Rows[rw].Cells[0].Text);
            showBlockInmates(block_num);
        }

        protected void inmate_select_Click(object sender, EventArgs e)
        {
            int rw = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            gridviewinmates_selected_num.Text = inmates_gridview.Rows[rw].Cells[0].Text;
            for (int i = 0; i < inmates_gridview.Rows.Count; i++)
            {
                inmates_gridview.Rows[i].BackColor = System.Drawing.Color.White;
            }
            inmates_gridview.Rows[rw].BackColor = System.Drawing.Color.LightGreen;
            int inmate_num = int.Parse(inmates_gridview.Rows[rw].Cells[0].Text);
            loadInmate(inmate_num);
        }

        protected void move_inmate_block_Click(object sender, EventArgs e)
        {
            DataTable blocks = dbAccess.getBlocks();
            inmate_block_dropdown.DataSource = blocks;
            inmate_block_dropdown.DataBind();
            inmate_block_dropdown.Enabled = true;
        }



        protected void save_inmate_block_Click(object sender, EventArgs e)
        {
            int inmate_num = int.Parse(gridviewinmates_selected_num.Text);
            int block_num = int.Parse(inmate_block_dropdown.SelectedValue);
            int selectedBlock = int.Parse(gridviewblocks_selected_num.Text);
            dbAccess.relocateInmate(inmate_num, block_num);
            inmate_block_dropdown.Enabled = false;
            showBlockInmates(selectedBlock);
        }

        protected void save_new_inmate_Click(object sender, EventArgs e)
        {
            string lastname = lastname_input.Value;
            string firstname= firstname_input.Value;
            int year_incarcerated = int.Parse(year_for_release_input.Value);
            int year_for_release = int.Parse(year_for_release_input.Value);
            int offense = int.Parse(new_inmate_offense_dropdown.SelectedValue);
            int block = int.Parse(new_inmate_block_dropdown.SelectedValue);
            bool male = new_inmate_male_checkbox.Checked;

            dbAccess.addInmate(firstname, lastname, male, block, year_incarcerated, offense, year_for_release);
        }

        protected void new_inmate_male_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            DataTable block = dbAccess.getBlocks();

            new_inmate_block_dropdown.DataSource = filterGender(new_inmate_male_checkbox.Checked, block);
            new_inmate_block_dropdown.DataBind();
        }
    }
}