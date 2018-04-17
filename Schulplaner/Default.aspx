<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Schulplaner._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">

        <div id="calendar"></div>

        <link rel="stylesheet" href="Content/fullcalendar.css" />
        <script src='Scripts/lib/jquery.min.js'></script>
        <script src='Scripts/lib/moment.min.js'></script>
        <script src='Scripts/fullcalendar.js'></script>

        <script type="text/javascript">

            $(document).ready(function () {
                var date = new Date();
                var d = date.getDate();
                var m = date.getMonth();
                var y = date.getFullYear();
                var calendar = $('#calendar').fullCalendar();
                

                });

            
        </script>

    </div>

</asp:Content>
