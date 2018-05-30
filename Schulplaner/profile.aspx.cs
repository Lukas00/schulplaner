using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Schulplaner
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fillValues(Int32.Parse(HttpContext.Current.User.Identity.Name));
        }

        protected void fillValues(int id)
        {
            Benutzer b = getUser(id);
            BenutzerID.Text = b.BenutzerID.ToString();
            Vorname.Text = b.Vorname;
            Nachname.Text = b.Nachname;
            Passwort.Text = b.Passwort;
            Email.Text = b.Email;
            Klasse.Text = b.Klasse;
            RollenID.Text = b.RollenID.ToString();
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

        protected Benutzer getUser(int id)
        {
            Benutzer b = new Benutzer();

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
                using (SqlCommand command = new SqlCommand("SELECT * FROM Benutzer WHERE BenutzerID=" + id, con))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // test.Text = reader.GetString(1);

                        Benutzer benutzer = new Benutzer();
                        try
                        {
                            benutzer.BenutzerID = reader.GetInt32(0);
                            benutzer.Vorname = reader.GetString(1).ToString();
                            benutzer.Nachname = reader.GetString(2);
                            benutzer.Passwort = reader.GetString(3);
                            benutzer.Email = reader.GetString(4);
                            benutzer.Klasse = reader.GetString(5);
                            benutzer.RollenID = reader.GetInt32(6);
                        } catch(Exception e)
                        {
                            test.Text = e.ToString();
                        }

                        return benutzer;
                    }
                }
                return null;
            }
        }
    }
}