﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Schulplaner
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login");
            }

            HashSet<Eintraege> events = new HashSet<Eintraege>();


            string connectionString = @"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\SchulplanerDB.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";
            //
            // In a using statement, acquire the SqlConnection as a resource.
            //
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //
                // Open the SqlConnection.
                //
                con.Open();
                //
                // The following code uses an SqlCommand based on the SqlConnection.
                //
                using (SqlCommand command = new SqlCommand(@"SELECT * From Eintraege 
                                                             INNER JOIN Beziehung_Benutzer_Eintraege
                                                             ON Beziehung_Benutzer_Eintraege.EintragsID = Eintraege.EintragsID
                                                             WHERE BenutzerID = " + HttpContext.Current.User.Identity.Name, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // test.Text = reader.GetString(1);

                            Eintraege eintrag = new Eintraege();
                            eintrag.EintragsID = reader.GetInt32(0);
                            eintrag.Titel = reader.GetString(1);
                            eintrag.Beschreibung = reader.GetString(2);
                            eintrag.TerminStart = reader.GetDateTime(3);
                            eintrag.TerminEnde = reader.GetDateTime(4);
                            // eintrag.ErinnerungsID = reader.GetInt32(5); // Im moment no Null, wills noni gmacht isch

                            events.Add(eintrag);
                        }
                    }
                }
            }

            string initCalendar = @"themeSystem: 'bootstrap3', selectable: true, header: {left: 'title', center: 'month agendaWeek list', right: 'today prev,next' }, 
                    navLink: true,
                    navLinkDayClick: function(date, jsEvent) {
                        console.log('day', date.format()); // date is a moment
                        console.log('coords', jsEvent.pageX, jsEvent.pageY);
                    },
                    select: function(startDate, endDate) {
                        window.location.replace('neuerEintrag');
                    },
                    eventClick: function(calEvent, jsEvent, view) {

                    window.location.replace('event?id=' + calEvent.id);

                    // change the border color just for fun
                    $(this).css('border-color', 'red');

                },                     
                ";

            string final = "events: [";

            int counter = 0; // für wenn es keine Einträge im Kalender hat

            foreach (Eintraege eintrag in events) // Alle Einträge in einen String umwandeln, den man danach als kalender braucht.
            {
                final += "{'allDay': '', 'title': '" + eintrag.Titel + "', 'id': '" + eintrag.EintragsID + "','end': '" + eintrag.TerminEnde.ToString() + "', 'start': '" + eintrag.TerminStart.ToString() + "'},";
                counter++;
            }
            if (counter > 0) { final = final.Remove(final.Length - 1); } else { } // Letztes Komma nach dem letzten Eintrag löschen, wenn es einträge im Kalender hat.
            final += "]";

            // String s = "events: [{'allDay': '', 'title': 'Test event12341234', 'id': '821','end': '2018-05-05 14:00:00', 'start': '2018-05-05 06:00:00'}]";

            // ClientScript.RegisterStartupScript(GetType(), "hwa", "$('#calendar').fullCalendar({events: 'myEvents.json'})", true);
            ClientScript.RegisterStartupScript(GetType(), "hwa", "$('#calendar').fullCalendar({" + initCalendar + final + "})", true);

        }


    }
}