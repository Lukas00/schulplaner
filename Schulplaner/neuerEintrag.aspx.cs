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

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            {//SQL Connection aufbauen
                SqlConnection con = new SqlConnection(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\SchulplanerDB.mdf;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;");

                {//Eingabe der Stored Procedure
                    SqlCommand Insertcommand = new SqlCommand("insert into Eintraege(Titel, Beschreibung, TerminStart, TerminEnde) values( @titel , + @beschreibung , @startdatum , @enddatum)", con); //datetime Format YYYY-MM-DD HH:MI:SS

                    Insertcommand.Parameters.AddWithValue("@titel", Titel.Text);
                    Insertcommand.Parameters.AddWithValue("@beschreibung", Beschreibung.Text);
                    Insertcommand.Parameters.AddWithValue("@startdatum", "2018-5-1 6:5:2");
                    Insertcommand.Parameters.AddWithValue("@enddatum", "2018-5-3 6:5:2");
                    //führt das Statement aus
                    con.Open();

                    Insertcommand.ExecuteNonQuery();

                    con.Close();

                    //setzt den Inhalt des Textfeldes wieder auf ""
                    if (IsPostBack)
                    {
                        adnkasd.Text = "";
                        dasiudasnd.Text = "";

                    }
                }
                //Message box zur bestätgigung, dass der Datensatz eingetragen wurde
                // MessageBox.Show("Termin wurde hinzugefügt");
            }
        }
    }
}