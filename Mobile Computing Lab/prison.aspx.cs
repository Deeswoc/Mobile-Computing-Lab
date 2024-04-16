using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mobile_Computing_Lab
{
    public partial class prison : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            refreshPrisonNames();
        }

        protected void CheckBox_male_CheckedChanged(object sender, EventArgs e)
        {
            refreshPrisonNames();
        }

        void refreshPrisonNames()
        {
            DropDownList_prisons.Items.Clear();
            if (CheckBox_male.Checked)
            {
                DropDownList_prisons.Items.Add("Barnett Street");
                DropDownList_prisons.Items.Add("Cow's Pen");
                DropDownList_prisons.Items.Add("Hamilton Pot");
                DropDownList_prisons.Items.Add("Sandy Bay");
            }else
            {
                DropDownList_prisons.Items.Add("Crow Path");
                DropDownList_prisons.Items.Add("McCook's Pen");
                DropDownList_prisons.Items.Add("Cristiana");
            }
        }
    }
}