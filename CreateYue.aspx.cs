using System;
using System.Collections.Generic;
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
            DateTime now = DateTime.Now;
            dsYue.InsertParameters.Clear();
            dsYue.InsertParameters.Add(new Parameter("CreatedBy", System.Data.DbType.String, txtCreatedBy.Text));
            dsYue.InsertParameters.Add(new Parameter("CreatedAt", System.Data.DbType.DateTime, now.ToString()));
            dsYue.InsertParameters.Add(new Parameter("ModifiedAt", System.Data.DbType.DateTime, now.ToString()));
            dsYue.InsertParameters.Add(new Parameter("Status", System.Data.DbType.Int16, "1"));
            dsYue.InsertParameters.Add(new Parameter("YueName", System.Data.DbType.String, txtName.Text));
            dsYue.InsertParameters.Add(new Parameter("YueDateTime", System.Data.DbType.DateTime, now.AddDays(1).ToString()));
            dsYue.InsertParameters.Add(new Parameter("Duration", System.Data.DbType.String, txtDuration.Text));
            dsYue.InsertParameters.Add(new Parameter("Minimum", System.Data.DbType.Int32, txtMinimum.Text));
            dsYue.InsertParameters.Add(new Parameter("Maximum", System.Data.DbType.Int32, txtMaximum.Text));
            dsYue.InsertParameters.Add(new Parameter("Tags", System.Data.DbType.String, ""));
            dsYue.InsertParameters.Add(new Parameter("Description", System.Data.DbType.String, txtDescription.Text));
            dsYue.InsertParameters.Add(new Parameter("Location", System.Data.DbType.String, txtLocation.Text));
            dsYue.InsertParameters.Add(new Parameter("MapUrl", System.Data.DbType.String, ""));
            dsYue.InsertParameters.Add(new Parameter("RegiterDue", System.Data.DbType.DateTime, now.AddDays(1).ToString()));
            dsYue.InsertParameters.Add(new Parameter("Notes", System.Data.DbType.String, ""));
            dsYue.Insert();

            lblMessage.Text = "Inserted";
        }
    }
}