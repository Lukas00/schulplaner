<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="newUser.aspx.cs" Inherits="Schulplaner.newUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Registrieren</h1>

    <asp:TextBox runat="server" ID="email" placeholder="email"></asp:TextBox>
    <asp:TextBox runat="server" ID="password" placeholder="password"></asp:TextBox>
    <asp:TextBox runat="server" ID="vorname" placeholder="vorname"></asp:TextBox>
    <asp:Button runat="server" ID="B_register" OnClick="register" />
    <asp:Label runat="server" ID="test"></asp:Label>

</asp:Content>
