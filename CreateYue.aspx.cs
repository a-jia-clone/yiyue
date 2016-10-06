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

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            DateTime startDateTime = DateTime.Parse(txtStartDate.Text + " " + txtStartTime.Text).ToUniversalTime();
            DateTime now = DateTime.Now.ToUniversalTime();
            dsYue.SelectParameters["CreatedBy"].DefaultValue = txtCreatedBy.Text;
            dsYue.SelectParameters["CreatedAt"].DefaultValue = now.ToString();
            dsYue.SelectParameters["ModifiedAt"].DefaultValue = now.ToString();
            dsYue.SelectParameters["Status"].DefaultValue = "1";
            dsYue.SelectParameters["YueName"].DefaultValue = txtName.Text;
            dsYue.SelectParameters["YueDateTime"].DefaultValue = startDateTime.ToString();
            dsYue.SelectParameters["Duration"].DefaultValue = txtDuration.Text;
            int min = 2;
            int.TryParse(txtMinimum.Text, out min);
            dsYue.SelectParameters["Minimum"].DefaultValue = min.ToString();
            int max = -1;
            int.TryParse(txtMaximum.Text, out max);
            dsYue.SelectParameters["Maximum"].DefaultValue = max.ToString();
            dsYue.SelectParameters["Tags"].DefaultValue = "";
            dsYue.SelectParameters["Description"].DefaultValue = txtDescription.Text;
            dsYue.SelectParameters["Location"].DefaultValue = txtLocation.Text;
            dsYue.SelectParameters["MapUrl"].DefaultValue = "";
            dsYue.SelectParameters["RegiterDue"].DefaultValue = now.AddDays(1).ToString();
            dsYue.SelectParameters["Notes"].DefaultValue = "";
            //Parameter returnValue = new Parameter("RETURN_VALUE");
            //returnValue.Direction = System.Data.ParameterDirection.ReturnValue;
            //dsYue.InsertParameters.Add(returnValue);
            DataView result = (DataView)dsYue.Select(DataSourceSelectArguments.Empty);
            //lblMessage.Text = e.Command.Parameters["@RETURN_VALUE"].Value.ToString();
        }

        protected void dsYue_Inserted(object sender, SqlDataSourceStatusEventArgs e)
        {

            lblMessage.Text = e.Command.Parameters["@RETURN_VALUE"].Value.ToString();

        }
    }
}