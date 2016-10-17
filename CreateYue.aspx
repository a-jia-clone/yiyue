<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateYue.aspx.cs" Inherits="YiYue.CreateYue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <link rel="icon" href="../../favicon.ico">
    <title>约起来！</title>
    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom styles for this template -->
    <link href="css/default.css" rel="stylesheet">
    <script src="js/jquery-3.1.1.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/yiyue.js"></script>
    <script>
        function tagOnClick(btn) {
            if (btn.className == "btn btn-secondary") {
                btn.className = "btn btn-info";
                selectTag(btn.value, btn.innerText);
            } else {
                btn.className = "btn btn-secondary";
                unSelectTag(btn.value, btn.innerText);
            }
        }

        function selectTag(id, name) {
            var divTags = document.getElementById("divTags");
            hidTags.value += id + ",";
            divTags.innerHTML += "<span>" + name + "</span>";
        }

        function unSelectTag(id, name) {
            var divTags = document.getElementById("divTags");
            hidTags.value = hidTags.value.replace(id + ",", "");
            divTags.innerHTML = divTags.innerHTML.replace("<span>" + name + "</span>", "");
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
        <asp:PlaceHolder ID="phMain" runat="server">
            <div class="row">
                <div class="col-xs-12">
                    <label class="sr-only">组织者微信号:</label>
                    <asp:TextBox ID="txtCreatedBy" CssClass="form-control" onfocus="this.select();" runat="server" placeholder="组织者微信号（必填）"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <label class="sr-only">标题:</label>
                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server" placeholder="标题（必填）"></asp:TextBox>
                    <asp:HiddenField ID="hidOffset" runat="server" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-6">
                    <label>活动日期（必填）:</label><br />
                    <asp:TextBox ID="txtStartDate" type="date" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-6">
                    <label>开始时间（必填）:</label><br />
                    <asp:TextBox ID="txtStartTime" type="time" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <label class="sr-only">地点:</label>
                    <asp:TextBox ID="txtLocation" CssClass="form-control" runat="server" placeholder="活动地点"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <label class="sr-only">详情:</label>
                    <asp:TextBox ID="txtDescription" CssClass="form-control" TextMode="MultiLine" runat="server" placeholder="活动详情"></asp:TextBox>
                </div>
            </div>
        </asp:PlaceHolder>
        <h4 onclick="$('#divMore').toggle()">
            <span class="glyphicon glyphicon-plus" aria-hidden="true"></span> 更多设置
        </h4>
        <div id="divMore" style="display: none">
            <div class="row">
                <div class="col-xs-2"><label>时长:</label></div>
                <div class="col-xs-10">
                    <asp:TextBox ID="txtDuration" CssClass="form-control" runat="server" placeholder="时长"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-2"><label>人数:</label></div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtMinimum" type="number" Text="2" onfocus="this.select();" CssClass="form-control" runat="server" placeholder="最少人数"></asp:TextBox>
                </div>
                <div class="col-xs-1">至</div>
                <div class="col-xs-4">
                    <asp:TextBox ID="txtMaximum" type="number" Text="不限" onfocus="this.select();" CssClass="form-control" runat="server" placeholder="最多人数"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">活动项目</button>
                    <asp:HiddenField ID="hidTags" runat="server" />
                </div>
                <div class="col-xs-7" id="divTags"></div>
<!-- Modal -->
<div id="myModal" class="modal fade" role="dialog">
  <div class="modal-dialog">
    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">活动项目</h4>
      </div>
      <div class="modal-body">
          <asp:Repeater ID="rptTags" runat="server" OnItemDataBound="rptTags_ItemDataBound">
              <ItemTemplate>
                  <div class="col-xs-3">
                      <button type="button" id="btnTag" runat="server" onclick="tagOnClick(this);" class="btn btn-secondary"></button>
                  </div>
              </ItemTemplate>
          </asp:Repeater>
      </div>
    </div>

  </div>
</div>  
            </div>
        </div>
        <div class="btn-group btn-wide">
        <asp:Button ID="btnCreate" CssClass="btn btn-primary btn-lg btn-wide" runat="server" Text="约起来" OnClick="btnCreate_Click" />
        </div>
        <asp:Label ID="lblMessage" CssClass="label label-default" runat="server"></asp:Label>
    </form>
</body>
</html>
