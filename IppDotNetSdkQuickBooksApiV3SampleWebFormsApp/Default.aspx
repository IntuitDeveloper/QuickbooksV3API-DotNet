<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IppDotNetSdkQuickBooksApiV3SampleWebFormsApp._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>Get started integrating your .NET application with IPP's QuickBooks APIs.</h1>
            </hgroup>
            <p>
                This sample application demonstrates an integration with the<mark>Intuit Partner Platform's QuickBooks APIs V3</mark> using the <a href="https://www.nuget.org/packages/IppDotNetSdkForQuickBooksApiV3/" target="_blank">IPP .NET SDK for QuickBooks API V3</a>.  To learn more about the QuickBooks APIs, please view our <a href="https://developer.intuit.com/docs/0025_quickbooksapi/0050_data_services/v3" target="_blank">documentation</a>.  To learn more about this SDK, please view the <a href="https://developer.intuit.com/docs/0025_quickbooksapi/0055_devkits/0150_ipp_.net_devkit_3.0" target="_blank">SDK documentation</a>.  To learn more about the Intuit Partner Platform, visit <a href="http://developer.intuit.com" target="_blank">http://developer.intuit.com</a>.
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>Running this sample application:</h3>
    <ol class="round">
        <li class="one">
            <h5>Configure your IPP application</h5>
            <a href="Configure">View the app settings</a> required on developer.intuit.com to test subscription and connection flows.
        </li>
        <li class="two">
            <h5>Set your keys</h5>
            <% if (IppDotNetSdkQuickBooksApiV3SampleWebFormsApp.RestHelper.appTokensSet())
               { %>
            Your keys are set!
            <% }
               else
               { %>
            <a href="ApplicationKeys">Set your application keys</a> in the web.config.
            <% } %> 
        </li>
        <li class="three">
            <h5>Create or login to your account</h5>
            <% if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
               { %>
            You're signed in!
            <% }
               else
               { %>
            <a href="/Account/Login">Sign In with Intuit</a> or <a href="/Account/Register">register</a> for an account.
            <% } %> 
        </li>
        <li class="four">
            <h5>Authorize a connection</h5>
            <% if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated && IppDotNetSdkQuickBooksApiV3SampleWebFormsApp.RestHelper.appTokensSet() && IppDotNetSdkQuickBooksApiV3SampleWebFormsApp.RestProfile.GetRestProfile().OAuthAccessToken.Length > 0)
               { %>
            You're connected!  <a href="ManageConnection">Manage your connection</a>.
            <% }
               else
               { %>
            <a href="ManageConnection">Connect a QuickBooks company file</a> to this application.
            <% } %> 
        </li>
        <li class="five">
            <h5>Make calls to the QuickBooks APIs</h5>
            <a href="CustomerList">Retrieve a list of customers</a> from the connected QuickBooks company file (realm).
        </li>
    </ol>
</asp:Content>
