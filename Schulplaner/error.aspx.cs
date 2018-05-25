using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Schulplaner
{
    public partial class error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            info.Text = "Sie haben keinen Zugriff auf diese Seite."; // Man könnte Art des Fehlers aufsplitten mit so einem Handler
        }
    }
}