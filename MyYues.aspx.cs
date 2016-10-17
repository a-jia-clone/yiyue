using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YiYue.App_Code;

namespace YiYue
{
    public partial class MyYues : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["owner"] != null && !String.IsNullOrEmpty(Request["owner"]))
                {
                    txtCreatedBy.Text = Request["owner"];
                    btnSearch_Click(btnSearch, new EventArgs());
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Yues search = new Yues();
            search.CreatedBy = txtCreatedBy.Text;
            Yues[] myYues = Yues.Search(search);

            if (myYues == null || myYues.Length == 0)
            {
                lblMessage.Text = "没有该组织者的活动。";
                return;
            }

            rptMyYues.DataSource = myYues.OrderBy(y => y.Status).ThenByDescending(y => y.YueDateTime);
            rptMyYues.DataBind();
        }

        protected void rptMyYues_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Yues yue = (Yues)e.Item.DataItem;
                HyperLink hlnkViewYue = (HyperLink)e.Item.FindControl("hlnkViewYue");
                hlnkViewYue.NavigateUrl = String.Format("ViewYue.aspx?yueId={0}&viewer={1}",
                    yue.YueID.ToString(),
                    txtCreatedBy.Text);

                Literal litName = (Literal)e.Item.FindControl("litName");
                Literal litStartDateTime = (Literal)e.Item.FindControl("litStartDateTime");
                Literal litLocation = (Literal)e.Item.FindControl("litLocation");
                Literal litTags = (Literal)e.Item.FindControl("litTags");

                litName.Text = yue.YueName;
                litStartDateTime.Text = Utilities.FormatDateTime(yue.YueDateTime, yue.Offset.Value, yue.Offset.Value);
                litLocation.Text = yue.Location;
                litTags.Text = Utilities.DisplayTags(yue.Tags);

                //attendance
                Literal litViewed = (Literal)e.Item.FindControl("litViewed");
                Literal litAccept = (Literal)e.Item.FindControl("litAccept");
                Interacts search = new Interacts();
                search.YueId = yue.YueID;
                Interacts[] players = Interacts.Search(search);
                litViewed.Text = players.Length.ToString();
                litAccept.Text = players.Count(p => p.Status == (byte)Interact_Status.Accept).ToString();
            }
        }
    }
}