<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="https://idaobin.com/test/jquery-3.2.1.js"></script>
    <script type="text/javascript">
        function JudgeUserName() {
            $.ajax({
                type: "GET",
                url: "UserHandler.ashx",
                dataType: "html",
                data: "userName=" + $("#txtUserName").val() + "&" + "pwd=" + $("#txtPwd").val(),
                beforeSend: function (XMLHttpRequest) {
                    $("#showResult").text("正在查询");
                    //Pause(this,100000);
                },
                success: function (msg) {
                    $("#showResult").html(msg);
                    $("#showResult").css("color", "red");
                },
                complete: function (XMLHttpRequest, textStatus) {
                    //隐藏正在查询图片
                },
                error: function () {
                    //错误处理
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtUserName" runat="server" onblur="JudgeUserName();"></asp:TextBox>
            <span id="showResult"></span>
        </div>
        <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
        <p>
            <input id="Button1" type="button" value="注册" onclick="JudgeUserName();" />
            </p>
    </form>
</body>
</html>
