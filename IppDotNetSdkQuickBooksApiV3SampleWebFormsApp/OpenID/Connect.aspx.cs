using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using DotNetOpenAuth.OpenId.RelyingParty;
using System.Web.Security;

namespace IppDotNetSdkQuickBooksApiV3SampleWebFormsApp.OpenID
{
    public partial class Connect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var openIdRelyingParty = new OpenIdRelyingParty();
            var openid_identifier = ConfigurationManager.AppSettings["openid_identifier"];
            var returnUrl = "~/OpenID/Connect";
            var response = openIdRelyingParty.GetResponse();
            if (response == null)
            {
                // Stage 2: user submitting Identifier
                Identifier id;
                if (Identifier.TryParse(openid_identifier, out id))
                {
                    IAuthenticationRequest request = openIdRelyingParty.CreateRequest(openid_identifier);
                    FetchRequest fetch = new FetchRequest();
                    fetch.Attributes.Add(new AttributeRequest(WellKnownAttributes.Contact.Email));
                    fetch.Attributes.Add(new AttributeRequest(WellKnownAttributes.Name.FullName));
                    fetch.Attributes.Add(new AttributeRequest("http://axschema.org/intuit/realmId"));
                    request.AddExtension(fetch);
                    request.RedirectToProvider();
                }
            }
            else
            {
                if (response.FriendlyIdentifierForDisplay == null)
                {
                    Response.Redirect("~/OpenID/Connect");
                }

                // Stage 3: OpenID Provider sending assertion response
                //Session["FriendlyIdentifier"] = response.FriendlyIdentifierForDisplay;
                FetchResponse fetch = response.GetExtension<FetchResponse>();
                if (fetch != null)
                {
                    var openIdEmail = fetch.GetAttributeValue(WellKnownAttributes.Contact.Email);
                    var openIdFullName = fetch.GetAttributeValue(WellKnownAttributes.Name.FullName);
                    var openIdRealmId = fetch.GetAttributeValue("http://axschema.org/intuit/realmId");

                    string userName = Membership.GetUserNameByEmail(openIdEmail);
                    if (userName == null)
                    {
                        Membership.CreateUser(openIdEmail, Guid.NewGuid().ToString(), openIdEmail);
                        FormsAuthentication.SetAuthCookie(openIdEmail, true);
                        if (Request.QueryString["Subscribe"] != null)
                        {
                            String csname = "DirectConnectScript";
                            Type cstype = this.GetType();
                            ClientScriptManager csm = Page.ClientScript;

                            // Check to see if the startup script is already registered.
                            if (!csm.IsStartupScriptRegistered(cstype, csname))
                            {
                                StringBuilder cstext = new StringBuilder();
                                cstext.AppendLine("<script>");
                                cstext.AppendLine("$(document).ready(function () {");
                                cstext.AppendLine("intuit.ipp.anywhere.directConnectToIntuit();");
                                cstext.AppendLine("});");
                                cstext.AppendLine("</script>");
                                csm.RegisterStartupScript(cstype, csname, cstext.ToString());
                            }
                        }
                    }
                    else if (Request.QueryString["Disconnect"] != null)
                    {
                        RestHelper.clearProfile(RestProfile.GetRestProfile());
                        Response.Redirect("~/ManageConnection");
                    }
                    else if (userName != null)
                    {
                        FormsAuthentication.SetAuthCookie(userName, true);
                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            Response.Redirect("~/Default");
                        }
                    }
                }

            }
        }
    }
}