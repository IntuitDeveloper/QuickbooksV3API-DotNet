using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;
using System.Configuration;

namespace IppDotNetSdkQuickBooksApiV3SampleWebFormsApp.OAuth
{
    public partial class Grant : System.Web.UI.Page
    {
        /// <summary>
        /// </summary>
        /// <param name="sender">Sender of the event.</param>
        /// <param name="e">Event Args.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            var oauth_callback_url = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath + ConfigurationManager.AppSettings["oauth_callback_url"];
            var consumerKey = ConfigurationManager.AppSettings["consumerKey"];
            var consumerSecret = ConfigurationManager.AppSettings["consumerSecret"];
            var oauthEndpoint = Constants.OauthEndPoints.IdFedOAuthBaseUrl;
            IToken token = (IToken)HttpContext.Current.Session["requestToken"];
            IOAuthSession session = CreateSession(consumerKey, consumerSecret, oauthEndpoint);
            IToken requestToken = session.GetRequestToken();
            HttpContext.Current.Session["requestToken"] = requestToken;
            var RequestToken = requestToken.Token;
            var TokenSecret = requestToken.TokenSecret;
            oauthEndpoint = Constants.OauthEndPoints.AuthorizeUrl + "?oauth_token=" + RequestToken + "&oauth_callback=" + UriUtility.UrlEncode(oauth_callback_url);
            Response.Redirect(oauthEndpoint);
        }

        /// <summary>
        /// Creates Session
        /// </summary>
        /// <returns>Returns OAuth Session</returns>
        protected IOAuthSession CreateSession(string consumerKey, string consumerSecret, string oauthEndpoint)
        {
            OAuthConsumerContext consumerContext = new OAuthConsumerContext
            {
                ConsumerKey = consumerKey,
                ConsumerSecret = consumerSecret,
                SignatureMethod = SignatureMethod.HmacSha1
            };
            return new OAuthSession(consumerContext,
                                            Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlRequestToken,
                                            oauthEndpoint,
                                            Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlAccessToken);
        }
    }
}