using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YiYue
{
    public partial class CreateYue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string strJS = String.Format(
                    @"$(document).ready(function(){{document.getElementById('{0}').value = new Date().getTimezoneOffset();}});",
                    hidOffset.ClientID);
                ScriptManager.RegisterStartupScript(this, typeof(Page), 
                    "", 
                    strJS,
                    true);
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Yues newYue = new Yues();
            DateTime startDateTime = DateTime.Parse(txtStartDate.Text + " " + txtStartTime.Text).ToUniversalTime();
            DateTime now = DateTime.Now.ToUniversalTime();
            int min = 2;
            int max = -1;
            int.TryParse(txtMinimum.Text, out min);
            int.TryParse(txtMaximum.Text, out max);

            newYue.CreatedBy = txtCreatedBy.Text;
            newYue.CreatedAt = now;
            newYue.ModifiedAt = now;
            newYue.Status = 1;
            newYue.YueName = txtName.Text;
            newYue.YueDateTime = startDateTime;
            newYue.Location = txtLocation.Text;
            newYue.Description = txtDescription.Text;
            newYue.Minimum = min;
            newYue.Maximum = max;
            newYue.Duration = txtDuration.Text;
            newYue.Offset = int.Parse(hidOffset.Value);

            newYue.Insert();
            lblMessage.Text = newYue.YueID.ToString();

            Response.Redirect(String.Format("ViewYue.aspx?yueid={0}&viewer={1}", newYue.YueID.ToString(), txtCreatedBy.Text));
        }
    }
}