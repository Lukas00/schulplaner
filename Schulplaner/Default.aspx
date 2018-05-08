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
                var calendar = $('#calendar').fullCalendar({
                    themeSystem: 'bootstrap3',
                    selectable: true,
                    header: {
                        left: 'title',
                        center: 'today prev,next',
                        right: 'month agendaWeek list'
                    },
                    navLink: true,
                    navLinkDayClick: function (date, jsEvent) {
                        console.log('day', date.format()); // date is a moment
                        console.log('coords', jsEvent.pageX, jsEvent.pageY);
                    },
                    select: function (startDate, endDate) {
                        alert('selected ' + startDate.format() + ' to ' + endDate.format());
                    },
                    events: [
                        {
                            id: '1',
                            resourceId: 'a',
                            title: 'Meeting',
                            start: '2018-05-14',
                            end: '2018-05-16'
                        }
                    ]
                });

                calendar.on('dayClick', function (date, jsEvent, view) {
                    console.log('clicked on ' + date.format());
                });

            });

            
        </script>

    </div>

</asp:Content>
