using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YiYue
{
    public partial class YuesMe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["player"] != null && !String.IsNullOrEmpty(Request["player"]))
                {
                    txtPlayer.Text = Request["player"];
                    btnSearch_Click(btnSearch, new EventArgs());
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Interacts search = new Interacts();
            search.Player = txtPlayer.Text;
            Interacts[] yuesMe = Interacts.SearchFull(search);

            if (yuesMe == null || yuesMe.Length == 0)
            {
                lblMessage.Text = "没有活动。";
                return;
            }

            rptYuesMe.DataSource = yuesMe.OrderBy(y => y.Yue.Status).ThenBy(y => y.Yue.YueDateTime);
            rptYuesMe.DataBind();
        }

        protected void rptYuesMe_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Interacts yue = (Interacts)e.Item.DataItem;
                HyperLink hlnkViewYue = (HyperLink)e.Item.FindControl("hlnkViewYue");
                hlnkViewYue.NavigateUrl = String.Format("ViewYue.aspx?yueId={0}&viewer={1}",
                    yue.YueId.ToString(),
                    txtPlayer.Text);

                Literal litName = (Literal)e.Item.FindControl("litName");
                Literal litStartDateTime = (Literal)e.Item.FindControl("litStartDateTime");
                Literal litLocation = (Literal)e.Item.FindControl("litLocation");

                litName.Text = yue.Yue.YueName;
                litStartDateTime.Text = Utilities.FormatDateTime(yue.Yue.YueDateTime, yue.Yue.Offset == null ? 0 : yue.Yue.Offset.Value, yue.Offset == null ? 0 : yue.Offset.Value);
                litLocation.Text = yue.Yue.Location;

                //attendance
                Literal litViewed = (Literal)e.Item.FindControl("litViewed");
                Literal litAccept = (Literal)e.Item.FindControl("litAccept");
                Interacts search = new Interacts();
                search.YueId = yue.YueId;
                Interacts[] players = Interacts.Search(search);
                litViewed.Text = players.Length.ToString();
                litAccept.Text = players.Count(p => p.Status == (byte)Interact_Status.Accept).ToString();
            }
        }
    }
}