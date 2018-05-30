<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rektoren.aspx.cs" Inherits="Schulplaner.rektoren" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Öffentliche Kalender verwalten</h1>

        <asp:Button runat="server" onClick="newCalendar" Text="Neuer öffentlicher Kalender" CssClass="btn btn-success" />

        <hr />

        <asp:DropDownList ID="DDL_Calendar" runat="server" CssClass="form-control"></asp:DropDownList>
        <asp:Button ID="edit" runat="server" Text="Bearbeiten" onClick="edit_calendar" CssClass="btn btn-success" />
        <asp:Button ID="delete" runat="server" Text="Löschen" OnClick="delete_calendar" CssClass="btn btn-danger" />

    </div>
</asp:Content>
