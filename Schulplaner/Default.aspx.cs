using System;
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM Eintraege", con))
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

            string initCalendar = @"themeSystem: 'bootstrap3', selectable: true, header: {left: 'title', center: 'today prev,next', right: 'month agendaWeek list' }, 
                    navLink: true,
                    navLinkDayClick: function(date, jsEvent) {
                        console.log('day', date.format()); // date is a moment
                        console.log('coords', jsEvent.pageX, jsEvent.pageY);
                    },
                    select: function(startDate, endDate) {
                        window.location.replace('neuerEintrag');
                    },
                    eventClick: function(calEvent, jsEvent, view) {

                    alert('Event: ' + calEvent.id);
                    alert('Coordinates: ' + jsEvent.pageX + ',' + jsEvent.pageY);
                    alert('View: ' + view.name);

                    window.location.replace('event?id=' + calEvent.id);

                    // change the border color just for fun
                    $(this).css('border-color', 'red');

                },                     
                ";

            string final = "events: [";

            foreach (Eintraege eintrag in events) // Alle Einträge in einen String umwandeln, den man danach als kalender braucht.
            {
                final += "{'allDay': '', 'title': '" + eintrag.Titel + "', 'id': '" + eintrag.EintragsID + "','end': '" + eintrag.TerminEnde.ToString() + "', 'start': '" + eintrag.TerminStart.ToString() + "'},";
            }
            final = final.Remove(final.Length - 1); // Letztes Komma nach dem letzten Eintrag löschen
            final += "]";

            // String s = "events: [{'allDay': '', 'title': 'Test event12341234', 'id': '821','end': '2018-05-05 14:00:00', 'start': '2018-05-05 06:00:00'}]";

            // ClientScript.RegisterStartupScript(GetType(), "hwa", "$('#calendar').fullCalendar({events: 'myEvents.json'})", true);
            ClientScript.RegisterStartupScript(GetType(), "hwa", "$('#calendar').fullCalendar({" + initCalendar + final + "})", true);

        }
        [System.Web.Services.WebMethod]
        public static void saySomething(string words)
        {
            // MessageBox.Show("Calling From Client Side");
        }


    }
}