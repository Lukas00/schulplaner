using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Schulplaner
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            test.Text = HttpContext.Current.User.Identity.Name;
        }

        protected void Log(object sender, EventArgs e)
        {
            String text = loginPass.Text;
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }


            String[] PW_and_ID = getPW(loginName.Text);

            if (hashString.Equals(PW_and_ID[0]))
            {
                test.Text = "eingeloggt";

                FormsAuthentication.SetAuthCookie(PW_and_ID[1], true); // Im AuthCookie die ID des Users speichern

                // HttpCookie aCookie = new HttpCookie("userName");
                Benutzer b = getUser.getBenutzer(Int32.Parse(PW_and_ID[1]));
                // aCookie.Value = "Hallo"; // b.Vorname + " ich bi so en idiot " + b.Nachname;
                // aCookie.Expires = DateTime.Now.AddDays(1);
                // Response.Cookies.Add(aCookie);

                Response.Cookies["userName"].Value = b.Vorname + " inbetween " + b.Nachname;
                Response.Cookies["userName"].Expires = DateTime.Now.AddDays(1);

                test.Text = PW_and_ID[1];

                Response.Redirect("~/");

            }
            else
            {
                test.Text = "Falsches Passwort oder falscher Benutzername";
            }

            

        }

        protected String[] getPW(String name)
        {

            String pw = "";
            String id = "";

            String statement = "SELECT Passwort, BenutzerID FROM Benutzer WHERE Email='" + name + "';";

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
                        pw = dr[0].ToString();
                        id = dr[1].ToString();
                    }
                }
                connection.Close();

                String[] final = { pw, id };

                return final;
            }


        }

    }
}