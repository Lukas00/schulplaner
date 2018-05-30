using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Schulplaner
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("Login");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            {//SQL Connection aufbauen
                SqlConnection con = new SqlConnection(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\SchulplanerDB.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;");

                {//Eingabe der Stored Procedure
                    SqlCommand Insertcommand = new SqlCommand("insert into Eintraege(Titel, Beschreibung, TerminStart, TerminEnde) OUTPUT INSERTED.EintragsID values( @titel , @beschreibung , @startdatum , @enddatum)", con); //datetime Format YYYY-MM-DD HH:MI:SS

                    Insertcommand.Parameters.AddWithValue("@titel", Titel.Text);
                    Insertcommand.Parameters.AddWithValue("@beschreibung", Beschreibung.Text);
                    Insertcommand.Parameters.AddWithValue("@startdatum", startdatum.SelectedDate.ToUniversalTime().AddDays(1).ToString("yyyy'-'MM'-'dd") + " " + startzeit.Text + ":00");
                    Insertcommand.Parameters.AddWithValue("@enddatum", enddatum.SelectedDate.ToUniversalTime().AddDays(1).ToString("yyyy'-'MM'-'dd") + " " + endzeit.Text + ":00");
                    //führt das Statement aus
                    con.Open();
                    
                    int modified = (int)Insertcommand.ExecuteScalar();
                    
                    if (con.State == System.Data.ConnectionState.Open) con.Close();

                    bindUserToEvent(modified);

                    //setzt den Inhalt des Textfeldes wieder auf ""
                    Response.Redirect("Login");
                }
                //Message box zur bestätgigung, dass der Datensatz eingetragen wurde
                // MessageBox.Show("Termin wurde hinzugefügt");
            }
        }

        protected void goBack(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }

        protected void bindUserToEvent(int id)
        {
            {//SQL Connection aufbauen
                SqlConnection con = new SqlConnection(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\SchulplanerDB.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;");

                {//Eingabe der Stored Procedure
                    SqlCommand Insertcommand = new SqlCommand("insert into Beziehung_Benutzer_Eintraege(BenutzerID, EintragsID) values( @BenutzerID , @EintragsID)", con); //datetime Format YYYY-MM-DD HH:MI:SS

                    Insertcommand.Parameters.AddWithValue("@BenutzerID", HttpContext.Current.User.Identity.Name);
                    Insertcommand.Parameters.AddWithValue("@EintragsID", id);
                    //führt das Statement aus
                    con.Open();

                    // Insertcommand.ExecuteNonQuery();
                    int modified = Insertcommand.ExecuteNonQuery();

                    if (con.State == System.Data.ConnectionState.Open) con.Close();



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