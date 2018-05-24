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
                    SqlCommand Insertcommand = new SqlCommand("insert into Benutzer(Email, Passwort, Vorname) values( @email , @password, @vorname)", con); //datetime Format YYYY-MM-DD HH:MI:SS

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
        }
    }
}