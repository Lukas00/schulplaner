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
            rolle.Items.Add(new ListItem("Admin"));
            rolle.Items.Add(new ListItem("Schüler"));
            rolle.Items.Add(new ListItem("Lehrer"));
            rolle.Items.Add(new ListItem("Rektoren"));
        }

        protected void goBack(object sender, EventArgs e)
        {
            Response.Redirect("Login");
        }

        protected void register(object sender, EventArgs e)
        {

            if (email.Text.Equals("") || vorname.Text.Equals("") || password.Text.Equals("") || nachname.Text.Equals("") || klasse.Text.Equals(""))
            {
                info.Text = "Bitte füllen Sie alle Felder korrekt aus.";

            }
            else
            {

                {//SQL Connection aufbauen
                    SqlConnection con = new SqlConnection(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\SchulplanerDB.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;");

                    {//Eingabe der Stored Procedure
                        SqlCommand Insertcommand = new SqlCommand("insert into Benutzer(Email, Passwort, Vorname, Nachname, Klasse, RollenID) values( @email , @password, @vorname, @nachname, @klasse, @rollenID)", con); //datetime Format YYYY-MM-DD HH:MI:SS

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

                        Insertcommand.Parameters.AddWithValue("@email", email.Text);
                        Insertcommand.Parameters.AddWithValue("@vorname", vorname.Text);
                        Insertcommand.Parameters.AddWithValue("@password", hashString);
                        Insertcommand.Parameters.AddWithValue("@nachname", nachname.Text);
                        Insertcommand.Parameters.AddWithValue("@klasse", klasse.Text);
                        if (rolle.SelectedValue.Equals("Schüler"))
                        {
                            Insertcommand.Parameters.AddWithValue("@rollenID", 2);
                        } else if (rolle.SelectedValue.Equals("Admin"))
                        {
                            Insertcommand.Parameters.AddWithValue("@rollenID", 1);
                        } else if (rolle.SelectedValue.Equals("Lehrer"))
                        {
                            Insertcommand.Parameters.AddWithValue("@rollenID", 3);
                        } else
                        {
                            Insertcommand.Parameters.AddWithValue("@rollenID", 4);
                        }
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
        }

        

    }
}