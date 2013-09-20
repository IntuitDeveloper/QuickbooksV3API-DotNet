<%@ Page Title="Manage QuickBooks Connection" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageConnection.aspx.cs" Inherits="IppDotNetSdkQuickBooksApiV3SampleWebFormsApp.ManageConnection" %>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>
    <article>
        <asp:PlaceHolder ID="notLoggedIn" runat="server" Visible="true">
            <h3>Status: <span style="color: red">Not Logged In</span></h3>
            <p>
                <a href="/Account/Login">Sign In with Intuit</a> or <a href="~/Account/Login">register</a> for an account.
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="notConnected" runat="server" Visible="false">
            <h3>Status: <span style="color: red">Not Connected</span></h3>
            <p>
                <ipp:connecttointuit></ipp:connecttointuit>
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="connected" runat="server" Visible="false">
            <h3>Status: <span style="color: green">Connected</span></h3>
            <p>
                You're connected!  You should now see the Blue Dot menu in the upper-right hand corner.  If you would like to disconnect your company file, click the Disconnect button below.  You can always reconnect with a couple of clicks.
            </p>
            <p>
                <asp:Button ID="disconnect" BackColor="Crimson" ForeColor="White" Text="Disconnect" runat="server" OnClick="disconnect_Click" />
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="appTokensNotFound" runat="server" Visible="true">
            <h3>Status: <span style="color: red">App Tokens Not Found</span></h3>
            <p>
                <a href="/ApplicationKeys">Set your appplication keys</a> in the web.config file.
            </p>
        </asp:PlaceHolder>
    </article>
    <aside>
        <h3>Help</h3>
        <p>
            Questions?  Check out our documentation.
        </p>
        <ul>
            <li><a id="A1" runat="server" href="https://developer.intuit.com/docs/0025_quickbooksapi/0060_auth_auth/widgets/0010_connect_button" target="_blank">Connect Button</a></li>
            <li><a id="A4" runat="server" href="https://developer.intuit.com/docs/0025_quickbooksapi/0010_getting_started/0020_connect/0010_from_within_your_app/implement_oauth_in_your_app" target="_blank">OAuth</a></li>
            <li><a id="A2" runat="server" href="https://developer.intuit.com/docs/0025_quickbooksapi/0060_auth_auth/widgets/blue_dot_menu" target="_blank">Blue Dot Menu</a></li>
            <li><a id="A3" runat="server" href="https://developer.intuit.com/docs/0025_quickbooksapi/0060_auth_auth/0015_disconnect_api" target="_blank">Disconnect</a></li>
        </ul>
    </aside>
</asp:Content>
