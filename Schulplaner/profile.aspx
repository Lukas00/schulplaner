<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="Schulplaner.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Profil</h1>

        ID<asp:TextBox runat="server" ID="BenutzerID" Enabled="false"></asp:TextBox>
        Vorname<asp:TextBox runat="server" ID="Vorname" Enabled="false"></asp:TextBox>
        Nachname<asp:TextBox runat="server" ID="Nachname" Enabled="false"></asp:TextBox>
        Passwort<asp:TextBox runat="server" ID="Passwort" Enabled="false" type="password"></asp:TextBox>
        Email<asp:TextBox runat="server" ID="Email" Enabled="false"></asp:TextBox>
        Klasse<asp:TextBox runat="server" ID="Klasse" Enabled="false"></asp:TextBox>
        RollenID<asp:TextBox runat="server" ID="RollenID" Enabled="false"></asp:TextBox>
    </div>
    <asp:Label ID="test" runat="server"></asp:Label>

</asp:Content>
