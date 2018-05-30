using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Schulplaner
{
    public partial class viewoeffentlicherKalender : System.Web.UI.Page
    {
        HashSet<OeffentlicherKalender> kalender = new HashSet<OeffentlicherKalender>();

        protected void Page_Load(object sender, EventArgs e)
        {
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
                using (SqlCommand command = new SqlCommand("SELECT * FROM OeffentlicherKalender", con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // test.Text = reader.GetString(1);

                        OeffentlicherKalender ok = new OeffentlicherKalender();
                        ok.KalenderID = reader.GetInt32(0);
                        ok.Name = reader.GetString(1);
                        ok.Beschreibung = reader.GetString(2);
                        // eintrag.ErinnerungsID = reader.GetInt32(5); // Im moment no Null, wills noni gmacht isch

                        kalender.Add(ok);

                        DDL_Calendar.Items.Add(new ListItem(ok.Name));

                    }
                }
            }
        }

        protected void viewCalendar(object sender, EventArgs e)
        {
            foreach (OeffentlicherKalender ok in kalender)
            {
                if (DDL_Calendar.SelectedValue == ok.Name)
                {
                    Response.Redirect("~/oeffentlicherKalender?id=" + ok.KalenderID);
                }
            }
        }
    }
}