<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Callback.aspx.cs" Inherits="IppDotNetSdkQuickBooksApiV3SampleWebFormsApp.OAuth.Callback" %>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Finishing OAuth Authentication Flow...</h1>
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="FooterContent" runat="server">
    <script type="text/javascript">
        try {

            var parentlocation = window.parent.opener.location.hostname;
            var currentlocation = window.location.hostname;
            if (parentlocation != currentlocation) {

                window.location = "/ManageConnection";
            }
            else {

                window.opener.location.href = window.opener.location.href;

                window.close();
            }
        }
        catch (e) {
            window.location = "/ManageConnection";
        }

    </script>
</asp:Content>
