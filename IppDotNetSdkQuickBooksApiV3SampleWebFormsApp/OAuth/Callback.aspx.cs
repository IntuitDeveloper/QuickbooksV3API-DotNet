using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;
using Intuit.Ipp.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IppDotNetSdkQuickBooksApiV3SampleWebFormsApp.OAuth
{
    public partial class Callback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.HasKeys())
            {
                var oauthVerifyer = Request.QueryString["oauth_verifier"].ToString();

                RestProfile profile = RestProfile.GetRestProfile();

                profile.RealmId = Request.QueryString["realmId"].ToString();

                switch (Request.QueryString["dataSource"].ToString().ToLower())
                {
                    case "qbo": profile.DataSource = (int)IntuitServicesType.QBO; break;
                    case "qbd": profile.DataSource = (int)IntuitServicesType.QBD; break;
                }

                OAuthConsumerContext consumerContext = new OAuthConsumerContext
                {
                    ConsumerKey = ConfigurationManager.AppSettings["consumerKey"].ToString(),
                    ConsumerSecret = ConfigurationManager.AppSettings["consumerSecret"].ToString(),
                    SignatureMethod = SignatureMethod.HmacSha1
                };

                IOAuthSession clientSession = new OAuthSession(consumerContext,
                                                Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlRequestToken,
                                                Constants.OauthEndPoints.IdFedOAuthBaseUrl,
                                                 Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlAccessToken);

                try
                {
                    IToken accessToken = clientSession.ExchangeRequestTokenForAccessToken((IToken)Session["requestToken"], oauthVerifyer);
                    profile.OAuthAccessToken = accessToken.Token;
                    profile.OAuthAccessTokenSecret = accessToken.TokenSecret;
                    profile.Save();
                }
                catch
                {

                }
            }
        }
    }
}