using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Profile;
using System.Web.Security;
using System.Web;

namespace IppDotNetSdkQuickBooksApiV3SampleWebFormsApp
{
    public class RestProfile : ProfileBase
    {
        public RestProfile() { }

        public static RestProfile GetRestProfile(string username)
        {
            return Create(username) as RestProfile;
        }

        public static RestProfile GetRestProfile()
        {
            return Create(Membership.GetUser().UserName) as RestProfile;
        }

        [SettingsAllowAnonymous(false)]
        public string RealmId
        {
            get { return base["RealmId"] as string; }
            set { base["RealmId"] = value; }
        }

        [SettingsAllowAnonymous(false)]
        public string OAuthAccessToken
        {
            get { return base["OAuthAccessToken"] as string; }
            set { base["OAuthAccessToken"] = value; }
        }

        [SettingsAllowAnonymous(false)]
        public string OAuthAccessTokenSecret
        {
            get { return base["OAuthAccessTokenSecret"] as string; }
            set { base["OAuthAccessTokenSecret"] = value; }
        }

        [SettingsAllowAnonymous(false)]
        public int DataSource
        {
            get { object dataSource = base["DataSource"]; if (!dataSource.Equals(null)) { return (int)dataSource; } else { return -1; } }
            set { base["DataSource"] = value; }
        }
    }
}