<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateYue.aspx.cs" Inherits="YiYue.CreateYue" %>

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
</head>
<body onload="loadData">
    <form id="form1" runat="server">
        <div class="container">
        <asp:PlaceHolder ID="phMain" runat="server">
            <div class="row">
                <label class="sr-only">组织者微信号:</label>
                <asp:TextBox ID="txtCreatedBy" CssClass="form-control" runat="server" placeholder="组织者微信号（必填）"></asp:TextBox>
            </div>
            <div class="row">
                <label class="sr-only">标题:</label>
                <asp:TextBox ID="txtName" CssClass="form-control" runat="server" placeholder="标题（必填）"></asp:TextBox>
                <asp:HiddenField ID="hidOffset" runat="server" />
            </div>
            <div class="row">
                <div class="col-xs-5">
                    <label>活动日期（必填）:</label><br />
                    <asp:TextBox ID="txtStartDate" type="date" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-5">
                    <label>开始时间（必填）:</label><br />
                    <asp:TextBox ID="txtStartTime" type="time" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <label class="sr-only">地点:</label>
                <asp:TextBox ID="txtLocation" CssClass="form-control" runat="server" placeholder="活动地点"></asp:TextBox>
            </div>
            <div class="row">
                <label class="sr-only">详情:</label>
                <asp:TextBox ID="txtDescription" CssClass="form-control" TextMode="MultiLine" runat="server" placeholder="活动详情"></asp:TextBox>
            </div>
        </asp:PlaceHolder>
        <h4 onclick="$('#divMore').toggle()">
            <span class="glyphicon glyphicon-plus" aria-hidden="true"></span> 更多设置
        </h4>
        <div id="divMore" style="display: none">
            <div class="row">
                <label class="sr-only">时长:</label>
                <asp:TextBox ID="txtDuration" CssClass="form-control" runat="server" placeholder="时长"></asp:TextBox>
            </div>
            <div class="row">
                <label class="sr-only">截止报名:</label>
                <asp:TextBox ID="txtRegisterDue" CssClass="form-control" runat="server" placeholder="截止报名"></asp:TextBox>
            </div>
            <div class="row">
                <label>最少人数:</label>
                <asp:TextBox ID="txtMinimum" Text="2" CssClass="form-control" runat="server" placeholder="最少人数"></asp:TextBox>
            </div>
            <div class="row">
                <label>最多人数:</label>
                <asp:TextBox ID="txtMaximum" Text="无限" CssClass="form-control" runat="server" placeholder="最多人数"></asp:TextBox>
            </div>
        </div>
        <div class="btn-group btn-wide">
        <asp:Button ID="btnCreate" CssClass="btn btn-primary btn-lg btn-wide" runat="server" Text="约起来" OnClick="btnCreate_Click" />
        </div>
        <asp:Label ID="lblMessage" CssClass="label label-default" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
