<%@ Page Title="Edit the Web.config" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApplicationKeys.aspx.cs" Inherits="IppDotNetSdkQuickBooksApiV3SampleWebFormsApp.ApplicationKeys" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Set your app keys.</h2>
    </hgroup>
    <p class="message-info">
        These keys are displayed when you create your IPP application.
    </p>
    <article>
        <section class="contact">
            <header>
                <h3>Set your App Tokens and Keys</h3>
            </header>
            <p>
                Copy your application token, consumer key and consumer secret from your development settings on developer.intuit.com to this applications's web.config file under configuration/appsettings.
            </p>
        </section>
        <p style="padding-top: 60px">
            <img src="Images/AppTokensAndKeys.PNG" />
        </p>
    </article>
    <aside>
        <h3>Help</h3>
        <p>
            Need help setting your web.config keys?
        </p>
        <ul>
            <li><a id="A1" runat="server" target="_blank" href="https://developer.intuit.com/docs/0025_quickbooksapi/0055_devkits/0150_ipp_.net_devkit_3.0">View the SDK documentation</a></li>
        </ul>
    </aside>
</asp:Content>
