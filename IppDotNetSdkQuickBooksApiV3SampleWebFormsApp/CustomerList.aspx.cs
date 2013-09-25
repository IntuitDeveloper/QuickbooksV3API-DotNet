using Intuit.Ipp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IppDotNetSdkQuickBooksApiV3SampleWebFormsApp
{
    public partial class CustomerList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated || !RestHelper.appTokensSet() || RestProfile.GetRestProfile().OAuthAccessToken.Length == 0)
                {
                    Response.Redirect("~/ManageConnection");
                }
                customersView.DataSource = RestHelper.getCustomerList(RestProfile.GetRestProfile());
                customersView.DataBind();
            }
            catch
            {
            }
        }
    }
}