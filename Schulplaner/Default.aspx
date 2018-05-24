<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Schulplaner._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div style="padding-top:30px">

        <div id="calendar"></div>

        <link rel="stylesheet" href="Content/fullcalendar.css" />
        <script src='Scripts/lib/jquery.min.js'></script>
        <script src='Scripts/lib/moment.min.js'></script>
        <script src='Scripts/fullcalendar.js'></script>

        <script type="text/javascript">

            
            function CallingServerSideFunction() {
                PageMethods.saySomething("Hallo Javascript");
            }
            
        </script>
        <asp:Label runat="server" id="test"></asp:Label>
    </div>

</asp:Content>
