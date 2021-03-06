﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThoughtWorks.QRCode.Codec;
using YiYue.App_Code;

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
                    Reload_Yue();
                }
                else
                {
                    lblMessage.Text = "没有相关活动";
                }
            }
        }


        protected void Reload_Yue()
        {
            int yueId = int.Parse(hidYueId.Value);
            Yues yue = Yues.Get(yueId);
            litName.Text = yue.YueName;
            litCreatedBy.Text = yue.CreatedBy;
            litStartDateTime.Text = Utilities.FormatDateTime(yue.YueDateTime, yue.Offset == null ? 0 : yue.Offset.Value, yue.Offset == null ? 0 : yue.Offset.Value);
            litLocation.Text = yue.Location;
            litMinimum.Text = yue.Minimum > 0 ? yue.Minimum.ToString() : "2";
            litMaximum.Text = yue.Maximum > 0 ? yue.Maximum.ToString() : "不限";
            litDescription.Text = yue.Description;
            litDuration.Text = yue.Duration;
            litTags.Text = Utilities.DisplayTags(yue.Tags);
            litRegisterDue.Text = yue.RegiterDue.ToString();
            litStatus.Text = Utilities.YueStatus(yue.Status);
            txtPost.Text = yue.DraftPost();
            Page.Title = Utilities.YueTitle(litName.Text, litStartDateTime.Text);

            //calculate attendancy
            Interacts search = new Interacts();
            search.YueId = yueId;
            Interacts[] players = Interacts.Search(search);
            btnViewedPlayers.InnerText = String.Format("{0} 人气", players.Length.ToString());
            StringBuilder strPlayers = new StringBuilder();
            foreach (Interacts player in players.OrderBy(p => p.UpdatedAt))
            {
                if (player.Status != null && player.Status.Value != (byte)Interact_Status.Viewed)
                    strPlayers.AppendFormat("{0} ({1})<br />", player.Player, Utilities.InteractStatus(player.Status));
                else
                    strPlayers.AppendFormat("{0}<br />", player.Player);
            }
            btnViewedPlayers.Attributes.Add("data-content", strPlayers.ToString());
            btnAcceptedPlayers.InnerText = String.Format("{0} 参加", players.Count(p => p.Status == (byte)Interact_Status.Accept).ToString());
            strPlayers = new StringBuilder();
            foreach (Interacts player in players.Where(p => p.Status == (byte)Interact_Status.Accept).OrderBy(p => p.UpdatedAt))
                strPlayers.AppendFormat("{0}<br />", player.Player);
            btnAcceptedPlayers.Attributes.Add("data-content", strPlayers.ToString());
            btnTentativePlayers.InnerText = String.Format("{0} 待定", players.Count(p => p.Status == (byte)Interact_Status.Tentative).ToString());
            strPlayers = new StringBuilder();
            foreach (Interacts player in players.Where(p => p.Status == (byte)Interact_Status.Tentative).OrderBy(p => p.UpdatedAt))
                strPlayers.AppendFormat("{0}<br />", player.Player);
            btnTentativePlayers.Attributes.Add("data-content", strPlayers.ToString());
            btnRejectedPlayers.InnerText = String.Format("{0} 婉拒", players.Count(p => p.Status == (byte)Interact_Status.Reject).ToString());
            strPlayers = new StringBuilder();
            foreach (Interacts player in players.Where(p => p.Status == (byte)Interact_Status.Reject).OrderBy(p => p.UpdatedAt))
                strPlayers.AppendFormat("{0}<br />", player.Player);
            btnRejectedPlayers.Attributes.Add("data-content", strPlayers.ToString());

            //To-Do: use wechat API to find the user identity
            pnlOwnerButtons.Visible = pnlPlayerButtons.Visible = false;
            if (Request["viewer"] != null && !String.IsNullOrEmpty(Request["viewer"]))
            {
                if (Request["viewer"] == yue.CreatedBy)
                {
                    pnlOwnerButtons.Visible = true;
                    btnActivate.Visible = btnExpire.Visible = btnCancel.Visible = true;
                    switch (yue.Status.Value)
                    {
                        case ((byte)Yue_Status.Active): btnActivate.Visible = false; break;
                        case ((byte)Yue_Status.Expired): btnExpire.Visible = false; break;
                        case ((byte)Yue_Status.Cancelled): btnCancel.Visible = false; break;
                    }

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

        protected void btnCard_Click(object sender, EventArgs e)
        {
            lblMessage.Text = Request.Url.ToString();
            imgQRCode.ImageUrl = String.Format("~/handlers/qrcode.ashx?code={0}", Server.UrlEncode(Request.Url.ToString()));
        }

        protected void btnActivate_Click(object sender, EventArgs e)
        {
            int yueId = int.Parse(hidYueId.Value);
            Yues yue = Yues.Get(yueId);
            yue.Status = (byte)Yue_Status.Active;
            yue.ModifiedAt = DateTime.Now.ToUniversalTime();
            yue.Update();
            Reload_Yue();
        }

        protected void btnExpire_Click(object sender, EventArgs e)
        {
            int yueId = int.Parse(hidYueId.Value);
            Yues yue = Yues.Get(yueId);
            yue.Status = (byte)Yue_Status.Expired;
            yue.ModifiedAt = DateTime.Now.ToUniversalTime();
            yue.Update();
            Reload_Yue();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            int yueId = int.Parse(hidYueId.Value);
            Yues yue = Yues.Get(yueId);
            yue.Status = (byte)Yue_Status.Cancelled;
            yue.ModifiedAt = DateTime.Now.ToUniversalTime();
            yue.Update();
            Reload_Yue();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int yueId = int.Parse(hidYueId.Value);
            Yues yue = Yues.Get(yueId);
            yue.Delete();
            Interacts search = new Interacts();
            search.YueId = yueId;
            Interacts[] replies = Interacts.Search(search);
            foreach (Interacts reply in replies)
            {
                reply.Delete();
            }

            Response.Redirect("~/CreateYue.aspx");
        }
    }
}