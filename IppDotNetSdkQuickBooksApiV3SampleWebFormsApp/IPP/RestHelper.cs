using DevDefined.OAuth.Consumer;
using DevDefined.OAuth.Framework;
using Intuit.Ipp.Core;
using Intuit.Ipp.Data;
using Intuit.Ipp.DataService;
using Intuit.Ipp.LinqExtender;
using Intuit.Ipp.QueryFilter;
using Intuit.Ipp.Security;
using Intuit.Ipp.Exception;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace IppDotNetSdkQuickBooksApiV3SampleWebFormsApp
{
    public static class RestHelper
    {

        public static void disconnectRealm(RestProfile profile)
        {
            RestHelper.callPlatform(profile, Constants.IppEndPoints.DisconnectUrl);
            clearProfile(profile);
        }

        public static void clearProfile(RestProfile profile)
        {
            profile.OAuthAccessToken = "";
            profile.OAuthAccessTokenSecret = "";
            profile.RealmId = "";
            profile.DataSource = -1;
            profile.Save();
        }

        public static string callPlatform(RestProfile profile, string url)
        {

            OAuthConsumerContext consumerContext = new OAuthConsumerContext
            {
                ConsumerKey = ConfigurationManager.AppSettings["consumerKey"].ToString(),
                SignatureMethod = SignatureMethod.HmacSha1,
                ConsumerSecret = ConfigurationManager.AppSettings["consumerSecret"].ToString()
            };

            OAuthSession oSession = new OAuthSession(consumerContext, Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlRequestToken,
                                  Constants.OauthEndPoints.AuthorizeUrl,
                                  Constants.OauthEndPoints.IdFedOAuthBaseUrl + Constants.OauthEndPoints.UrlAccessToken);

            oSession.ConsumerContext.UseHeaderForOAuthParameters = true;
            if (profile.OAuthAccessToken.Length > 0)
            {
                oSession.AccessToken = new TokenBase
                {
                    Token = profile.OAuthAccessToken,
                    ConsumerKey = ConfigurationManager.AppSettings["consumerKey"].ToString(),
                    TokenSecret = profile.OAuthAccessTokenSecret
                };

                IConsumerRequest conReq = oSession.Request();
                conReq = conReq.Get();
                conReq = conReq.ForUrl(url);
                try
                {
                    conReq = conReq.SignWithToken();
                    return conReq.ReadBody();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return "";
        }

        private static DataService getDataService(RestProfile profile)
        {
            ServiceContext serviceContext = getServiceContext(profile);
            return new DataService(serviceContext);
        }

        private static ServiceContext getServiceContext(RestProfile profile)
        {
            var consumerKey = ConfigurationManager.AppSettings["consumerKey"].ToString();
            var consumerSecret = ConfigurationManager.AppSettings["consumerSecret"].ToString();
            OAuthRequestValidator oauthValidator = new OAuthRequestValidator(profile.OAuthAccessToken, profile.OAuthAccessTokenSecret, consumerKey, consumerSecret);
            return new ServiceContext(profile.RealmId, (IntuitServicesType)profile.DataSource, oauthValidator);
        }

        public static List<Customer> getCustomerList(RestProfile profile)
        {
            ServiceContext serviceContext = getServiceContext(profile);
            QueryService<Customer> customerQueryService = new QueryService<Customer>(serviceContext);
            return customerQueryService.Select(c => c).ToList();
        }

        public static bool appTokensSet()
        {
            try
            {
                var consumerKey = ConfigurationManager.AppSettings["consumerKey"].ToString();
                var consumerSecret = ConfigurationManager.AppSettings["consumerSecret"].ToString();
                return consumerKey.Length > 0 && consumerSecret.Length > 0;
            }
            catch { return false; }
        }
    }
}