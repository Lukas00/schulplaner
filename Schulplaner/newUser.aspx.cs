using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Schulplaner
{
    public partial class newUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void register(object sender, EventArgs e)
        {
            {//SQL Connection aufbauen
                SqlConnection con = new SqlConnection(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\SchulplanerDB.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;");

                {//Eingabe der Stored Procedure
                    SqlCommand Insertcommand = new SqlCommand("insert into Benutzer(Email, Passwort, Vorname, Nachname) values( @email , @password, @vorname, @nachname)", con); //datetime Format YYYY-MM-DD HH:MI:SS

                    // Passwort Crypto
                    String text = password.Text;
                    byte[] bytes = Encoding.UTF8.GetBytes(text);
                    SHA256Managed hashstring = new SHA256Managed();
                    byte[] hash = hashstring.ComputeHash(bytes);
                    string hashString = string.Empty;
                    foreach (byte x in hash)
                    {
                        hashString += String.Format("{0:x2}", x);
                    }

                    test.Text = hashString;

                    Insertcommand.Parameters.AddWithValue("@email", email.Text);
                    Insertcommand.Parameters.AddWithValue("@vorname", vorname.Text);
                    Insertcommand.Parameters.AddWithValue("@password", hashString);
                    Insertcommand.Parameters.AddWithValue("@nachname", nachname.Text);
                    //führt das Statement aus
                    con.Open();

                    Insertcommand.ExecuteNonQuery();

                    con.Close();

                    //setzt den Inhalt des Textfeldes wieder auf ""
                    if (IsPostBack)
                    {
                        email.Text = "";
                        password.Text = "";

                    }
                }

                
                //Message box zur bestätgigung, dass der Datensatz eingetragen wurde
                // MessageBox.Show("Termin wurde hinzugefügt");
            }
            // createExampleEvent();
        }

        protected int getUserID()
        {
            int id = 99; // einen Wert initialisieren

            String statement = "SELECT BenutzerID FROM Benutzer WHERE Email='" + email.Text + "';";

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\SchulplanerDB.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;";


            using (SqlCommand cmd = new SqlCommand(statement))
            {
                cmd.Connection = connection;

                //    try
                //   {
                connection.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string treatment = dr[0].ToString();
                        id = Int32.Parse(dr[0].ToString());
                    }
                }
                connection.Close();
                return id;
                
            }
        }

        protected void createExampleEvent()
        {
            {
                {//SQL Connection aufbauen
                    SqlConnection con = new SqlConnection(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\SchulplanerDB.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;");

                    {//Eingabe der Stored Procedure
                        SqlCommand Insertcommand = new SqlCommand("insert into Beziehung_Benutzer_Eintraege(BenutzerID, EintragsID) values( @BenutzerID , @EintragsID)", con);

                        Insertcommand.Parameters.AddWithValue("@BenutzerID", getUserID());
                        Insertcommand.Parameters.AddWithValue("@EintragsID", 7.ToString()); // Vordefiniertes Ereignis (ID = 7)
                        //führt das Statement aus
                        con.Open();

                        Insertcommand.ExecuteNonQuery();

                        con.Close();

                        //setzt den Inhalt des Textfeldes wieder auf ""
                        if (IsPostBack)
                        {
                            

                        }
                    }
                    //Message box zur bestätgigung, dass der Datensatz eingetragen wurde
                    // MessageBox.Show("Termin wurde hinzugefügt");
                }
            }
        }
    }
}