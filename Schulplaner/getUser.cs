using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Schulplaner
{
    public class getUser
    {

        public static Benutzer getBenutzer(int id)
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
                            // benutzer.Vorname = reader.GetString(1).ToString();
                            // benutzer.Nachname = reader.GetString(2);
                            benutzer.Passwort = reader.GetString(3);
                            benutzer.Email = reader.GetString(4);
                            // benutzer.Klasse = reader.GetString(5);
                            // benutzer.RollenID = reader.GetInt32(6);
                        }
                        catch (Exception e)
                        {
                            // test.Text = e.ToString();
                        }

                        return benutzer;
                    }
                }
                return null;
            
            }
        }

    }
}