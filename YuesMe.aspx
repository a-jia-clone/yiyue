<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YuesMe.aspx.cs" Inherits="YiYue.YuesMe" %>

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
    <script src="js/bootstrap.min.js"></script>
    <script src="js/yiyue.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <asp:TextBox ID="txtPlayer" CssClass="form-control" runat="server" placeholder="微信号（必填）"></asp:TextBox>
                <asp:Button ID="btnSearch" CssClass="btn btn-primary btn-sm" runat="server" Text="查找" OnClick="btnSearch_Click" />
            </div>
        </div>
        <div class="list-group">
            <asp:Label ID="lblMessage" CssClass="label label-default" runat="server"></asp:Label>
            <asp:Repeater ID="rptYuesMe" runat="server" OnItemDataBound="rptYuesMe_ItemDataBound">
                <ItemTemplate>
                    <asp:HyperLink ID="hlnkViewYue" runat="server">
                      <h4 class="list-group-item-heading"><asp:Literal ID="litName" runat="server"></asp:Literal></h4>
                      <span>人气：<asp:Literal ID="litViewed" runat="server"></asp:Literal></span>
                      <span>参加：<asp:Literal ID="litAccept" runat="server"></asp:Literal></span>
                      <p class="list-group-item-text">
                          <asp:Literal ID="litStartDateTime" runat="server"></asp:Literal>
                          <asp:Literal ID="litLocation" runat="server"></asp:Literal>
                      </p>
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
