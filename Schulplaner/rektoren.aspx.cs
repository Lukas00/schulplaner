using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Schulplaner
{
    public partial class rektoren : System.Web.UI.Page
    {

        HashSet<OeffentlicherKalender> kalender = new HashSet<OeffentlicherKalender>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (getUser.getBenutzer(Int32.Parse(HttpContext.Current.User.Identity.Name)).RollenID != 4) // RollenID == 4 --> User == Rektor / Wenn User kein Rektor wird ihm die Seite nicht angezeigt
            {
                Response.Redirect("~/error?type=" + getUser.getBenutzer(Int32.Parse(HttpContext.Current.User.Identity.Name)).RollenID);
            }

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

        protected void edit_calendar(object sender, EventArgs e)
        {
            foreach(OeffentlicherKalender ok in kalender)
            {
                if(DDL_Calendar.SelectedValue == ok.Name)
                {
                    Response.Redirect("~/oeffentlicherKalender?id=" + ok.KalenderID);
                }
            }
        }

        protected void delete_calendar(object sender, EventArgs e)
        {
            foreach (OeffentlicherKalender ok in kalender)
            {
                if (DDL_Calendar.SelectedValue == ok.Name)
                {
                    {//SQL Connection aufbauen
                        SqlConnection con = new SqlConnection(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\SchulplanerDB.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;");

                        {//Eingabe der Stored Procedure
                            SqlCommand Insertcommand = new SqlCommand("DELETE FROM OeffentlicherKalender WHERE KalenderID=" + ok.KalenderID, con); //datetime Format YYYY-MM-DD HH:MI:SS

                            //führt das Statement aus
                            con.Open();

                            Insertcommand.ExecuteNonQuery();

                            con.Close();

                            Response.Redirect("rektoren");

                        }
                        //Message box zur bestätgigung, dass der Datensatz eingetragen wurde
                        // MessageBox.Show("Termin wurde hinzugefügt");
                    }
                }
            }
        }

        protected void newCalendar(object sender, EventArgs e)
        {
            Response.Redirect("~/newCalendar");
        }

        
    }
}