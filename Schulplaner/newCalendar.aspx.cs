using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Schulplaner
{
    public partial class newCalendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (getUser.getBenutzer(Int32.Parse(HttpContext.Current.User.Identity.Name)).RollenID != 4) // RollenID == 4 --> User == Rektor / Wenn User kein Rektor wird ihm die Seite nicht angezeigt
            {
                Response.Redirect("~/error?type=" + getUser.getBenutzer(Int32.Parse(HttpContext.Current.User.Identity.Name)).RollenID);
            }
        }

        protected void goBack(object sender, EventArgs e)
        {
            Response.Redirect("~/rektoren");
        }

        protected void create(object sender, EventArgs e)
        {
            {//SQL Connection aufbauen
                SqlConnection con = new SqlConnection(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\SchulplanerDB.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;");

                {//Eingabe der Stored Procedure
                    SqlCommand Insertcommand = new SqlCommand("INSERT INTO OeffentlicherKalender(Name, Beschreibung) VALUES ( @name , + @beschreibung)", con); //datetime Format YYYY-MM-DD HH:MI:SS

                    Insertcommand.Parameters.AddWithValue("@name", name.Text);
                    Insertcommand.Parameters.AddWithValue("@beschreibung", beschreibung.Text);
                    //führt das Statement aus
                    con.Open();

                    Insertcommand.ExecuteNonQuery();

                    con.Close();

                    //setzt den Inhalt des Textfeldes wieder auf ""
                    if (IsPostBack)
                    {
                        name.Text = "";
                        beschreibung.Text = "";
                        info.Text = "Der Kalender wurde hinzugefügt.";

                    }
                }
                //Message box zur bestätgigung, dass der Datensatz eingetragen wurde
                // MessageBox.Show("Termin wurde hinzugefügt");
            }
        }
    }
}