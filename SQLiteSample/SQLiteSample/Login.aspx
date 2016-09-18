<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SQLiteSample.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <!-- Bootstrap -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />

    <style>
        body{
            background-color:#eee;
        }
        .page-center{
            margin-left:auto;
            margin-right:auto;
            max-width:300px;
        }
    </style>
</head>

<body>
    <div class="container">
        <form id="form1" runat="server" class="page-center">
            <h1 class="text-center">ログイン</h1>

            <div class="bg-danger">
                <asp:Label ID="ErrorMessage" runat="server"></asp:Label>
            </div>

            <div class="form-group">
                <label for="LoginID">ログインID</label>
                <asp:TextBox ID="LoginID" runat="server" ClientIDMode="Static" CssClass="form-control" placeholder="LoginID"></asp:TextBox>
            </div>

            <div class="form-group">
                        <label for="Password">Password</label>
                        <asp:TextBox ID="Password" type="password" runat="server" ClientIDMode="Static" CssClass="form-control" placeholder="Password"></asp:TextBox>
            </div>

            <asp:Button ID="LoginButton" runat="server" CssClass="btn btn-lg btn-block btn-default" Text="ログイン" OnClick="LoginButton_Click" />
        </form>
    </div>
</body>
</html>
