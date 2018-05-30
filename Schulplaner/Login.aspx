<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Schulplaner.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
            <h1>Login</h1>
            <asp:TextBox runat="server" ID="loginName" placeholder="Email" CssClass="form-control"></asp:TextBox>
            <asp:TextBox runat="server" ID="loginPass" type="password" CssClass="form-control" placeholder="Passwort"></asp:TextBox>
            <asp:Button runat="server" OnClick="Log" Text="Login" CssClass="btn btn-success" />
            <asp:Label runat="server" ID="test" visible="false"></asp:Label>
            <asp:Button runat="server" onclick="createUser" Text="Registrieren" CssClass="btn btn-info" />
        </div>


</asp:Content>
