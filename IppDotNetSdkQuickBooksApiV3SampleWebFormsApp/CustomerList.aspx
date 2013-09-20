<%@ Page Title="QuickBooks Customer List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="IppDotNetSdkQuickBooksApiV3SampleWebFormsApp.CustomerList" %>

<asp:Content ID="mainContent" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
    </hgroup>
    <p class="message-info">
        These customers are pulled from the QuickBooks REST APIs using the IPP .NET SDK.
    </p>
    <article>
        <div class="datagrid">
            <asp:ListView ID="customersView" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("DisplayName")%></td>
                        <td><%# Eval("CompanyName")%></td>
                        <td><%# Eval("Balance", "{0:c}")%></td>
                        <td><%# Eval("TotalRevenue", "{0:c}")%></td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="alt">
                        <td><%# Eval("DisplayName")%></td>
                        <td><%# Eval("CompanyName")%></td>
                        <td><%# Eval("Balance", "{0:c}")%></td>
                        <td><%# Eval("TotalRevenue", "{0:c}")%></td>
                    </tr>
                </AlternatingItemTemplate>
                <LayoutTemplate>
                    <table>
                        <thead>
                            <tr>
                                <th>Customer Name</th>
                                <th>Company Name</th>
                                <th>Balance</th>
                                <th>Total Revenue</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr id="ItemPlaceholder" runat="server">
                            </tr>
                        </tbody>
                        <tfoot>
                            <tr>
                                <td colspan="4" style="padding: 0px">
                                    <div id="paging" style="padding: 5px">
                                        <asp:DataPager ID="CustomerDataPager" runat="server" PageSize="10" PagedControlID="customersView" QueryStringField="page">
                                            <Fields>
                                                <asp:NextPreviousPagerField
                                                    FirstPageText="First"
                                                    LastPageText="Last"
                                                    NextPageText="Next"
                                                    PreviousPageText="Back" />
                                            </Fields>
                                        </asp:DataPager>
                                    </div>
                                </td>
                            </tr>
                        </tfoot>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </article>
    <aside>
        <h3>Help</h3>
        <p>
            Questions?  Check out our documentation.
        </p>
        <ul>
            <li><a id="A1" runat="server" href="https://developer.intuit.com/docs/0025_quickbooksapi/0055_devkits/0150_ipp_.net_devkit_3.0" target="_blank">IPP .NET SDK</a></li>
            <li><a id="A4" runat="server" href="https://developer.intuit.com/docs/0025_quickbooksapi/0050_data_services/v3/030_entity_services_reference/customer" target="_blank">V3 Customer</a></li>
            <li><a id="A2" runat="server" href="https://developer.intuit.com/docs/0025_quickbooksapi/0055_devkits/0150_ipp_.net_devkit_3.0/query_filters" target="_blank">SDK Query Filters</a></li>
        </ul>
    </aside>
</asp:Content>
