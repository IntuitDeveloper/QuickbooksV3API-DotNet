using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IppDotNetSdkQuickBooksApiV3SampleWebFormsApp.OpenID
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String csname = "LogoutScript";
            Type cstype = this.GetType();
            ClientScriptManager csm = Page.ClientScript;

            // Check to see if the startup script is already registered.
            if (!csm.IsStartupScriptRegistered(cstype, csname))
            {
                StringBuilder cstext = new StringBuilder();
                cstext.AppendLine("<script>");
                cstext.AppendLine("$(document).ready(function () {");
                cstext.AppendLine("intuit.ipp.anywhere.logout(");
                cstext.AppendLine("function(){");
                cstext.AppendLine("window.location = '../Account/Login';");
                cstext.AppendLine("});");
                cstext.AppendLine("});");
                cstext.AppendLine("</script>");
                csm.RegisterStartupScript(cstype, csname, cstext.ToString());
            }
        }
    }
}