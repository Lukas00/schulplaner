<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="newUser.aspx.cs" Inherits="Schulplaner.newUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Registrieren</h1>

    <asp:TextBox runat="server" ID="email" placeholder="Email"></asp:TextBox>
    <asp:TextBox runat="server" ID="password" placeholder="Passwort"></asp:TextBox>
    <asp:TextBox runat="server" ID="vorname" placeholder="Nachname"></asp:TextBox>
    <asp:TextBox runat="server" ID="nachname" placeholder="Nachname"></asp:TextBox>
    <asp:TextBox runat="server" ID="class" placeholder="I3a"></asp:TextBox>
    <asp:TextBox runat="server" ID="role" placeholder="Schüler"></asp:TextBox>
    <asp:Button runat="server" ID="B_register" OnClick="register" />
    <asp:Label runat="server" ID="test"></asp:Label>

</asp:Content>
