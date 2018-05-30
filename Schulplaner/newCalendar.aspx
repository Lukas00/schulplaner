<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="newCalendar.aspx.cs" Inherits="Schulplaner.newCalendar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Neuer Kalender</h1>
    <asp:TextBox ID="name" runat="server" placeholder="Kalender Namen" CssClass="form-control"></asp:TextBox>
    <asp:TextBox ID="beschreibung" runat="server" placeholder="Kalender Beschreibung" CssClass="form-control"></asp:TextBox>

    <asp:Button ID="Erstellen" Text="Erstellen" runat="server" OnClick="create" CssClass="btn btn-success" />
    <asp:Button runat="server" Text="Abbrechen" onClick="goBack" CssClass="btn btn-warning" />
    <asp:Label ID="info" runat="server" style="color:green;"></asp:Label>

</asp:Content>
