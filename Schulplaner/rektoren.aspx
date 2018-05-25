<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rektoren.aspx.cs" Inherits="Schulplaner.rektoren" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Button runat="server" onClick="newCalendar" Text="Neuer öffentlicher Kalender" />
    <hr />
    <asp:DropDownList ID="DDL_Calendar" runat="server"></asp:DropDownList><asp:Button ID="edit" runat="server" Text="Bearbeiten" onClick="edit_calendar"/><asp:Button ID="delete" runat="server" Text="Löschen" OnClick="delete_calendar" />

</asp:Content>
