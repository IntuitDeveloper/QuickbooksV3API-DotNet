<%@ Page Title="Configure Your App Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Configure.aspx.cs" Inherits="IppDotNetSdkQuickBooksApiV3SampleWebFormsApp.Configure" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Subscribe to and launch this sample app.</h2>
    </hgroup>
    <p class="message-info">
        These configuration settings are only required if you are testing the link between the application and Intuit's App Center.  Examples include testing the subscription (TryBuy) flow, launching and disconnecting the application from Intuit's App Center. 
    </p>
    <article>
        <section class="contact">
            <header>
                <h3>Host Name Domain</h3>
            </header>
            <p>
                example.com
            </p>
        </section>
        <section class="contact">
            <header>
                <h3>App URL</h3>
            </header>
            <p>
                https://localhost:62288/OpenID/Connect.aspx
            </p>
        </section>
        <section class="contact">
            <header>
                <h3>Disconnect Landing URL</h3>
            </header>
            <p>
                https://localhost:62288/OpenID/Connect.aspx?Disconnect=true
            </p>
        </section>
        <section class="contact">
            <header>
                <h3>Manage Users URL</h3>
            </header>
            <p>
                https://localhost:62288/OpenID/Connect.aspx?Manage=true
            </p>
        </section>
        <section class="contact">
            <header>
                <h3>OpenID URL</h3>
            </header>
            <p>
                https://localhost:62288/OpenID/Connect.aspx?Subscribe=true
            </p>
        </section>
        <section class="contact">
            <header>
                <h3>Data Source</h3>
            </header>
            <p>
                Choose QuickBooks Online.</p>
        </section>
       
    </article>
    <aside>
        <h3>Help</h3>
        <p>
            Need help configuring your app?
        </p>
        <ul>
            <li><a id="A1" runat="server" target="_blank" href="https://developer.intuit.com/docs/0025_quickbooksapi/0010_getting_started/0010_signup/create_your_app_profile">Create Your App Profile</a></li>
        </ul>
    </aside>
</asp:Content>
