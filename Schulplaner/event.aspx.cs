using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Schulplaner
{
    public partial class _event : System.Web.UI.Page
    {
        Eintraege eintrag = new Eintraege();

        protected void Page_Load(object sender, EventArgs e)
        {

            int id;
            try
            {
                id = Int32.Parse(Request.Params["id"]);
            }
            catch
            {
                id = 5; // Beispiel Termin
            }

           

            try
            {
                eintrag = getEvent(id);
            } catch (Exception ex)
            {
            }

            fillTextBoxes();
        }

        // Fill TextBoxes with the Information from the Database
        protected void fillTextBoxes()
        {
            title.InnerText = "Eintrag: " + eintrag.Titel;
            beschreibung.Text = eintrag.Beschreibung;
            starttime.Text = eintrag.TerminStart.ToShortDateString() + " " + eintrag.TerminStart.ToShortTimeString();
            endtime.Text = eintrag.TerminEnde.ToShortDateString() + " " + eintrag.TerminEnde.ToShortTimeString();
        }

        protected void update(object sender, EventArgs e)
        {
            Console.WriteLine("Feature coming soon.");
        }
        protected void delete(object sender, EventArgs e)
        {
            Console.WriteLine("Feature coming soon.");
        }

        protected void goBack(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }

        protected Eintraege getEvent(int id)
        {
            Eintraege e = new Eintraege();

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
                using (SqlCommand command = new SqlCommand("SELECT * FROM Eintraege WHERE EintragsID=" + id, con))
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

                        return eintrag;
                    }
                }
            }
            return null; // falls kein Eintrag gefunden wird, einfach null zurückgeben.
        }
    }
}