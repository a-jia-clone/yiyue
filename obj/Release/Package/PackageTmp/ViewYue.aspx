<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewYue.aspx.cs" Inherits="YiYue.ViewYue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="icon" href="../../favicon.ico">
    <title>约起来！</title>
    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom styles for this template -->
    <link href="css/default.css" rel="stylesheet">
    <script src="js/jquery-3.1.1.min.js"></script>
    <script src="js/yiyue.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
        <asp:PlaceHolder ID="phMain" runat="server">
            <div class="row">
                <label class="col-xs-3">标题:</label>
                <h1 class="col-xs-9"><asp:Literal ID="litName" runat="server"></asp:Literal></h1>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <label>组织者:</label>
                </div>
                <div class="col-xs-5">
                    <asp:Literal ID="litCreatedBy" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <label>活动日期时间:</label>
                </div>
                <div class="col-xs-5">
                    <asp:Literal ID="litStartDateTime" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <label>地点:</label>
                </div>
                <div class="col-xs-9">
                    <asp:Literal ID="litLocation" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <label>详情:</label>
                    <asp:Literal ID="litDescription" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <label>时长:</label>
                </div>
                <div class="col-xs-9">
                    <asp:Literal ID="litDuration" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="row" style="display: none;">
                <div class="col-xs-3">
                    <label>截止报名:</label>
                </div>
                <div class="col-xs-9">
                    <asp:Literal ID="litRegisterDue" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <label>人数:</label>
                </div>
                <div class="col-xs-9">
                    <asp:Literal ID="litMinimum" runat="server"></asp:Literal> 至 <asp:Literal ID="litMaximum" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3"><asp:Literal ID="litViewed" runat="server"></asp:Literal><label>人气</label></div>
                <div class="col-xs-3"><asp:Literal ID="litAccept" runat="server"></asp:Literal><label>参加</label></div>
                <div class="col-xs-3"><asp:Literal ID="litTentative" runat="server"></asp:Literal><label>待定</label></div>
                <div class="col-xs-3"><asp:Literal ID="litReject" runat="server"></asp:Literal><label>婉拒</label></div>
            </div>
        </asp:PlaceHolder>
        <asp:Panel ID="pnlOwnerButtons" CssClass="btn-group btn-group-lg" role="group" runat="server">
            <asp:Button ID="btnCard" CssClass="btn btn-primary" runat="server" Text="邀请卡" />
            <asp:Button ID="btnShare" CssClass="btn btn-primary" runat="server" Text="链接分享" />
            <asp:Button ID="btnPost" CssClass="btn btn-primary" runat="server" Text="接龙贴" />
        </asp:Panel>
        <asp:Panel ID="pnlPlayerButtons" CssClass="btn-group btn-group-lg" role="group" Visible="false" runat="server">
            <asp:Button ID="btnAccept" CssClass="btn btn-primary" runat="server" Text="我来！" OnClick="btnAccept_Click" />
            <asp:Button ID="btnTentative" CssClass="btn btn-primary" runat="server" Text="想想" OnClick="btnTentative_Click" />
            <asp:Button ID="btnReject" CssClass="btn btn-primary" runat="server" Text="来不了" OnClick="btnReject_Click" />
            <asp:Button ID="btnViewed" CssClass="btn btn-primary" runat="server" Text="观望" OnClick="btnViewed_Click" />
            <div class="row">
                <label class="sr-only">报名者微信号:</label>
                <asp:TextBox ID="txtPlayer" CssClass="form-control" runat="server" placeholder="报名者微信号（必填）"></asp:TextBox>
                <asp:HiddenField ID="hidYueId" runat="server" />
                <asp:HiddenField ID="hidOffset" Value="0" runat="server" />
            </div>
            <div class="row">
                <label class="sr-only">留言:</label>
                <asp:TextBox ID="txtNotes" CssClass="form-control" TextMode="MultiLine" runat="server" placeholder="留言"></asp:TextBox>
            </div>
        </asp:Panel>
        <asp:Label ID="lblMessage" CssClass="label label-default" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
