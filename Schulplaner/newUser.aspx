<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="newUser.aspx.cs" Inherits="Schulplaner.newUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Registrieren</h1>

        <asp:TextBox runat="server" ID="email" placeholder="Email" CssClass="form-control"></asp:TextBox>
        <asp:TextBox runat="server" ID="password" placeholder="Passwort" type="password" CssClass="form-control"></asp:TextBox>
        <asp:TextBox runat="server" ID="vorname" placeholder="Vorname" CssClass="form-control"></asp:TextBox>
        <asp:TextBox runat="server" ID="nachname" placeholder="Nachname" CssClass="form-control"></asp:TextBox>
        <asp:TextBox runat="server" ID="klasse" placeholder="I3a" CssClass="form-control"></asp:TextBox>
        <asp:DropDownList runat="server" ID="rolle" CssClass="form-control"></asp:DropDownList>
        <asp:Button runat="server" ID="B_register" OnClick="register" Text="Registrieren" CssClass="btn btn-success" />
        <asp:Button runat="server" ID="Back" OnClick="goBack" Text="Abbrechen" CssClass="btn btn-warning" />
        <asp:Label runat="server" ID="info"></asp:Label>
    </div>
</asp:Content>
