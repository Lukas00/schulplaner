<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="Schulplaner.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1>Profil</h1>

        <div class="form-group">
            <label for="BenutzerID">ID:</label>
            <asp:TextBox runat="server" ID="BenutzerID" Enabled="false" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Vorname">Vorname:</label>
            <asp:TextBox runat="server" ID="Vorname" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Nachname">Nachname:</label>
            <asp:TextBox runat="server" ID="Nachname" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Passwort">Passwort</label>
            <asp:TextBox runat="server" ID="Passwort" type="password" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Email">Email:</label>
            <asp:TextBox runat="server" ID="Email" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Klasse">Klasse:</label>
            <asp:TextBox runat="server" ID="Klasse" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="RollenID">RollenID:</label>
            <asp:TextBox runat="server" ID="RollenID" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button runat="server" id="save" Text="Speichern" OnClick="update" CssClass="btn btn-success" />
        <asp:Button runat="server" id="löschen" Text="Löschen" OnClick="delete" CssClass="btn btn-danger" />
        <asp:Button runat="server" ID="back" Text="Zurück" OnClick="goBack" CssClass="btn btn-warning" />
        <asp:Label ID="test" runat="server"></asp:Label>
    </div>
    

</asp:Content>
