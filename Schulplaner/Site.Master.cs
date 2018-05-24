using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Schulplaner
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Cookies["userName"] != null)
            {
                currentUser.Text = Server.HtmlEncode(Request.Cookies["userName"].Value);
            } else
            {
                currentUser.Text = "fehler";
            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Cookies["userName"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("~/");
        }

        protected void toProfile(object sender, EventArgs e)
        {
            Response.Redirect("profile");
        }
    }
}