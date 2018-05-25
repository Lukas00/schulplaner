<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="oeffentlicherKalender.aspx.cs" Inherits="Schulplaner.oeffentlicherKalender" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div style="padding-top:30px">

        <div id="calendar"></div>

        <link rel="stylesheet" href="Content/fullcalendar.css" />
        <script src='Scripts/lib/jquery.min.js'></script>
        <script src='Scripts/lib/moment.min.js'></script>
        <script src='Scripts/fullcalendar.js'></script>

        <asp:Label runat="server" id="test"></asp:Label>
    </div>

</asp:Content>
