<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewYue.aspx.cs" Inherits="YiYue.ViewYue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width,minimum-scale=1.0,maximum-scale=1.0,initial-scale=1.0" user-scalable="no">
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
        function copyPost() {
            var t = document.getElementById('txtPost');
            t.select();
            try {
                document.execCommand('copy');
                t.blur();
                alert('接龙贴已经成功复制');
            }
            catch (err) {
                alert('不支持自动复制，请长按文字然后全选及复制');
            }
        }

        function getDeleteConfirm() {
            return confirm("确认要彻底删除该活动吗？所有已经报名的记录也将被彻底删除。此操作无法被复原。");
        }

        function hideAllPopover() {
            $('[data-toggle="popover"]').popover('hide');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
        <asp:PlaceHolder ID="phMain" runat="server">
            <div class="row">
                <h1 class="col-xs-12"><asp:Literal ID="litName" runat="server"></asp:Literal></h1>
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
                    <label>活动时间:</label>
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
                <div class="col-xs-3">
                    <label>详情:</label>
                </div>
                <div class="col-xs-9">
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
            <div class="row">
                <div class="col-xs-3">
                    <label>约啥？</label>
                </div>
                <div class="col-xs-9">
                    <asp:Literal ID="litTags" runat="server"></asp:Literal>
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
                <div class="col-xs-3">
                    <label>目前状态:</label>
                </div>
                <div class="col-xs-9">
                    <asp:Literal ID="litStatus" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-3">
                    <button id="btnViewedPlayers" runat="server" type="button" title="看过的人" onclick="hideAllPopover();" class="btn btn-secondary btn-sm" 
                        data-html="true" data-toggle="popover" data-placement="right"></button>
                </div>
                <div class="col-xs-3">
                    <button id="btnAcceptedPlayers" runat="server" type="button" title="参加的人" onclick="hideAllPopover();" class="btn btn-success btn-sm" 
                        data-html="true" data-toggle="popover" data-placement="right"></button>
                </div>
                <div class="col-xs-3">
                    <button id="btnTentativePlayers" runat="server" type="button" title="待定的人" onclick="hideAllPopover();" class="btn btn-warning btn-sm" 
                        data-html="true" data-toggle="popover" data-placement="left"></button>
                </div>
                <div class="col-xs-3">
                    <button id="btnRejectedPlayers" runat="server" type="button" title="婉拒的人" onclick="hideAllPopover();" class="btn btn-danger btn-sm" 
                        data-html="true" data-toggle="popover" data-placement="left"></button>
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:Panel ID="pnlOwnerButtons" CssClass="row" runat="server">
            <div class="row">
                <div class="col-xs-12">
                    <asp:Button ID="btnCard" Width="30%" CssClass="btn btn-primary" data-toggle="modal" data-target="#modalInvitationCard" runat="server" Text="邀请卡" OnClick="btnCard_Click" />
                    <button type="button" style="width: 30%;" class="btn btn-primary" data-toggle="modal" data-target="#modalShare">链接分享</button>
                    <button type="button" style="width: 30%;" class="btn btn-primary" data-toggle="modal" data-target="#modalPost">接龙贴</button>
                </div>
                <div class="col-xs-12">
                    <asp:Button ID="btnActivate" Width="30%" CssClass="btn btn-success btn-sm" runat="server" Text="开放报名" OnClick="btnActivate_Click" />
                    <asp:Button ID="btnExpire" Width="30%" CssClass="btn btn-warning btn-sm" runat="server" Text="截止报名" OnClick="btnExpire_Click" />
                    <asp:Button ID="btnCancel" Width="30%" CssClass="btn btn-warning btn-sm" runat="server" Text="取消活动" OnClick="btnCancel_Click" />
                    <asp:Button ID="btnDelete" Width="30%" OnClientClick='return getDeleteConfirm();' CssClass="btn btn-danger btn-sm" runat="server" Text="彻底删除" OnClick="btnDelete_Click" />
                </div>
            </div>
<!-- Modal 邀请卡 -->
<div id="modalInvitationCard" class="modal fade" role="dialog">
  <div class="modal-dialog">
    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">邀请卡</h4>
      </div>
      <div class="modal-body">
          <asp:Image ID="imgQRCode" Height="250px" Width="250px" runat="server" />
      </div>
    </div>
  </div>
</div>  
<!-- Modal 链接分享-->
<div id="modalShare" class="modal fade" role="dialog">
  <div class="modal-dialog">
    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">链接分享</h4>
      </div>
      <div class="modal-body">
          <p>点击右上角"..."选择“发送给朋友”</p>
      </div>
    </div>
  </div>
</div>  
<!-- Modal 接龙贴-->
<div id="modalPost" class="modal fade" role="dialog">
  <div class="modal-dialog">
    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">接龙贴</h4>
      </div>
      <div class="modal-body">
          <asp:TextBox ID="txtPost" TextMode="MultiLine" Width="100%" Rows="16" runat="server"></asp:TextBox>
      </div>
      <div class="modal-footer">
          <button type="button" class="btn btn-default" onclick="copyPost();">复制</button>
      </div>
    </div>
  </div>
</div>  
<!-- Modal 删除确认-->
<div id="modalConfirmDeletion" class="modal fade" role="dialog">
  <div class="modal-dialog">
    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">确认删除</h4>
      </div>
      <div class="modal-body">
          <p>确认要彻底删除该活动吗？所有已经报名的记录也将被彻底删除。此操作无法被复原。</p>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-danger" data-dismiss="modal">确认删除</button>
        <button type="button" class="btn btn-warning" data-dismiss="modal">不删除</button>
      </div>
    </div>
  </div>
</div> 
            <div class="row">
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlPlayerButtons" Visible="false" runat="server">
            <div class="row">
                <div class="col-xs-12">
                    <label class="sr-only">报名者微信号:</label>
                    <asp:TextBox ID="txtPlayer" CssClass="form-control" runat="server" placeholder="报名者微信号（必填）"></asp:TextBox>
                    <asp:HiddenField ID="hidYueId" runat="server" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <label class="sr-only">留言:</label>
                    <asp:TextBox ID="txtNotes" CssClass="form-control" TextMode="MultiLine" runat="server" placeholder="留言"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <asp:Button ID="btnAccept" Width="30%" CssClass="btn btn-success" runat="server" Text="我来！" OnClick="btnAccept_Click" />
                    <asp:Button ID="btnTentative" Width="30%" CssClass="btn btn-warning" runat="server" Text="想想" OnClick="btnTentative_Click" />
                    <asp:Button ID="btnReject" Width="30%" CssClass="btn btn-danger" runat="server" Text="来不了" OnClick="btnReject_Click" />
                    <asp:Button ID="btnViewed" Visible="false" CssClass="btn btn-primary" runat="server" Text="观望" OnClick="btnViewed_Click" />
                </div>
            </div>
        </asp:Panel>
        <asp:HiddenField ID="hidOffset" Value="0" runat="server" />
        <asp:Label ID="lblMessage" CssClass="label label-default" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
