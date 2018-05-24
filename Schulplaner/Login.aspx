<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Schulplaner.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
            <h1>Login</h1>
            <asp:TextBox runat="server" ID="loginName" placeholder="Email"></asp:TextBox>
            <asp:TextBox runat="server" ID="loginPass" type="password" placeholder="Passwort"></asp:TextBox>
            <asp:Button runat="server" OnClick="Log" Text="Login" />
            <asp:Label runat="server" ID="test"></asp:Label>
        </div>

</asp:Content>
