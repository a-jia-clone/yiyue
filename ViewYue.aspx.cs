using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YiYue
{
    public partial class ViewYue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int yueId = 0;
                if (Request["yueid"] != null && int.TryParse(Request["yueid"], out yueId))
                {
                    //retrieve yue information
                    hidYueId.Value = yueId.ToString();
                    Yues yue = Yues.Get(yueId);
                    litName.Text = yue.YueName;
                    litCreatedBy.Text = yue.CreatedBy;
                    litStartDateTime.Text = yue.YueDateTime.ToString();
                    litLocation.Text = yue.Location;
                    litMinimum.Text = yue.Minimum > 0 ? yue.Minimum.ToString() : "2";
                    litMaximum.Text = yue.Maximum > 0 ? yue.Maximum.ToString() : "不限";
                    litDescription.Text = yue.Description;
                    litDuration.Text = yue.Duration;
                    litRegisterDue.Text = yue.RegiterDue.ToString();

                    //calculate attendancy
                    Interacts search = new Interacts();
                    search.YueId = yueId;
                    Interacts[] players = Interacts.Search(search);
                    litViewed.Text = players.Length.ToString();
                    //litTentative.Text = players.Count

                    //To-Do: use wechat API to find the user identity
                    if (Request["isowner"] != null && Request["isowner"].ToString() == "yes")
                    {
                        pnlOwnerButtons.Visible = true;
                        pnlPlayerButtons.Visible = false;
                    }
                    else
                    {
                        pnlOwnerButtons.Visible = false;
                        pnlPlayerButtons.Visible = true;
                    }
                }
                else
                {
                    lblMessage.Text = "没有相关活动";
                }
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            reply(3, txtNotes.Text);
        }

        protected void btnTentative_Click(object sender, EventArgs e)
        {
            reply(2, txtNotes.Text);
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            reply(1, txtNotes.Text);
        }

        //To-Do: later will be removed when API ready
        protected void btnViewed_Click(object sender, EventArgs e)
        {
            reply(0, txtNotes.Text);
        }

        protected void reply(byte status, string notes)
        {
            Interacts interact = new Interacts();
            interact.YueId = int.Parse(hidYueId.Value);
            interact.Player = txtPlayer.Text;
            interact.Notes = notes;
            interact.Status = status;
            interact.UpdatedAt = interact.ViewedAt = DateTime.Now.ToUniversalTime();
            interact.Insert();

            lblMessage.Text = "谢谢";
        }
    }
}