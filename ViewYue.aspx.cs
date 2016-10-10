using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;

public enum Yue_Status
{
    Active = 0,
    Expired = 1,
    Closed = 2
}

public enum Interact_Status
{
    Viewed = 0,
    Accept = 1,
    Tentative = 2,
    Reject = 3
}

public static class Utilities
{
    public static string FormatDateTime(DateTime? dt, int offset, int local_offset)
    {
        string retStr = "";
        if (dt == null) return retStr;
        DateTime offsetDt = dt.Value.AddMinutes(0 - offset);
        if (offsetDt.Year != DateTime.Now.Year)
            retStr = String.Format("{0}年", offsetDt.Year.ToString());
        retStr += String.Format("{0}月{1}日 {2} {3}时{4}",
            offsetDt.Month.ToString(),
            offsetDt.Day.ToString(),
            ChineseWeekday((byte)offsetDt.DayOfWeek).ToString(),
            offsetDt.Hour.ToString(),
            offsetDt.Minute > 0 ? offsetDt.Minute.ToString() + "分" : "整");

        return retStr;
    }

    public static string ChineseWeekday(byte number)
    {
        switch (number)
        {
            case 0: return "周日";
            case 1: return "周一";
            case 2: return "周二";
            case 3: return "周三";
            case 4: return "周四";
            case 5: return "周五";
            case 6: return "周六";
            default: return "";
        }
    }
}

namespace YiYue
{
    public partial class ViewYue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Reset offset based on user's local browser
                string strJS = String.Format(
                    @"$(document).ready(function(){{document.getElementById('{0}').value = new Date().getTimezoneOffset();}});",
                    hidOffset.ClientID);
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "loadData",
                    strJS,
                    true);

                //Load Yue by ID
                int yueId = 0;
                if (Request["yueid"] != null && int.TryParse(Request["yueid"], out yueId))
                {
                    //retrieve yue information
                    hidYueId.Value = yueId.ToString();
                    Yues yue = Yues.Get(yueId);
                    litName.Text = yue.YueName;
                    litCreatedBy.Text = yue.CreatedBy;
                    litStartDateTime.Text = Utilities.FormatDateTime(yue.YueDateTime, yue.Offset == null ? 0 : yue.Offset.Value, yue.Offset == null ? 0 : yue.Offset.Value);
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
                    litAccept.Text = players.Count(p => p.Status == (byte)Interact_Status.Accept).ToString();
                    litTentative.Text = players.Count(p => p.Status == (byte)Interact_Status.Tentative).ToString();
                    litReject.Text = players.Count(p => p.Status == (byte)Interact_Status.Reject).ToString();

                    //To-Do: use wechat API to find the user identity
                    pnlOwnerButtons.Visible = pnlPlayerButtons.Visible = false;
                    if (Request["viewer"] != null && !String.IsNullOrEmpty(Request["viewer"]))
                    {
                        if (Request["viewer"] == yue.CreatedBy)
                        {
                            pnlOwnerButtons.Visible = true;
                            pnlPlayerButtons.Visible = false;
                        }
                        else
                        {
                            txtPlayer.Text = Request["viewer"];
                            pnlOwnerButtons.Visible = false;
                            pnlPlayerButtons.Visible = true;

                            //mark viewed -- To-Do: put readable notes
                            Interacts interact = reply((byte)Interact_Status.Viewed, "");
                            switch (interact.Status)
                            {
                                case 0: btnViewed.Enabled = false; break;
                                case 1: btnAccept.Enabled = false; break;
                                case 2: btnTentative.Enabled = false; break;
                                case 3: btnReject.Enabled = false; break;
                            }
                        }
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
            reply((byte)Interact_Status.Reject, txtNotes.Text);
        }

        protected void btnTentative_Click(object sender, EventArgs e)
        {
            reply((byte)Interact_Status.Tentative, txtNotes.Text);
        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            reply((byte)Interact_Status.Accept, txtNotes.Text);
        }

        //To-Do: later will be removed when API ready
        protected void btnViewed_Click(object sender, EventArgs e)
        {
            reply((byte)Interact_Status.Viewed, txtNotes.Text);
        }

        protected Interacts reply(byte status, string notes)
        {
            //check if aleady viewed
            Interacts search = new Interacts();
            search.YueId = int.Parse(hidYueId.Value);
            search.Player = txtPlayer.Text;
            Interacts[] replies = Interacts.Search(search).OrderBy(r => r.UpdatedAt.Value).ToArray<Interacts>();
            Interacts theReply = new Interacts();
            if (replies != null && replies.Length > 0)
            {
                theReply = replies[replies.Length - 1];
                if (replies.Length > 1) //more than 1 replies, only keep the last one
                {
                    for (int i = 0; i < replies.Length - 1; i++)
                    {
                        replies[i].Delete();
                    }
                }
                if (status > (byte)Interact_Status.Viewed) //update the status other than 'viewed'
                {
                    theReply.Notes = notes;
                    theReply.Status = status;
                    theReply.UpdatedAt = DateTime.Now.ToUniversalTime();
                    theReply.Offset = int.Parse(hidOffset.Value);
                    theReply.Update();
                }
            }
            else
            {
                theReply.YueId = int.Parse(hidYueId.Value);
                theReply.Player = txtPlayer.Text;
                theReply.Notes = notes;
                theReply.Status = status;
                theReply.UpdatedAt = theReply.ViewedAt = DateTime.Now.ToUniversalTime();
                theReply.Offset = int.Parse(hidOffset.Value);
                theReply.Insert();
            }
            lblMessage.Text = "谢谢";

            return theReply;
        }
    }
}