<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="viewoeffentlicherKalender.aspx.cs" Inherits="Schulplaner.viewoeffentlicherKalender" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Öffentliche Kalender anschauen</h1>
    <asp:DropDownList ID="DDL_Calendar" runat="server" CssClass="form-control"></asp:DropDownList><asp:Button runat="server" ID="view" OnClick="viewCalendar" Text="Anschauen" CssClass="btn btn-success" />

</asp:Content>
