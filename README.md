Quickbooks API V3 - ASP.NET Web Forms Sample App (C#)
======================


This .NET sample app demonstrates an integration with the [QuickBooks API v3](https://developer.intuit.com/docs/0025_quickbooksapi/0050_data_services/v3).  This app supports Intuit's OpenID for creating and authorizing a user to log in, as well as OAuth for authorizing a connection to a QuickBooks company file (realm).  Subscriptions from Intuit's App Center can be tested using the settings below, as well as in-app connections to QuickBooks.

Requirements
-------------------------

In addition to the changes in the previous section, certain references are auto-linked:


* [NuGet](http://www.nuget.org/)
* .NET Framework 4.6.1
* IIS Express
* Windows 7

With this sample app, you can
-------------------------------

* Create an account and sign in to the application
* Authenticate and provision accounts with Single Sign-In feature using Open ID
* Authorize access to QuickBooks Company Data using OAuth
* Access QuickBooks data
* Use Disconnect link to disconnect from QuickBooks
* Use Intuit Logout feature to sign out of app and the Intuit App Center
* Use the Direct Connect to Intuit feature to test the Try/Buy flow from Intuit App Center
* Configure the SDK for custom logging, serialization and retry mechanisms
 
To get started
------------

* Create an account in [developer.intuit.com](http://developer.intuit.com) 
* Create an app on [developer.intuit.com](http://developer.intuit.com) and the associated app token, consumer key, and consumer secret.[
* Copy the app tokens and keys to the project's web.config file
* Configure your app to test the flows from the App Center and Blue Dot menu

For more information
------------

* [Visit](https://developer.intuit.com) developer.intuit.com to become an IPP Developer and read more about the APIs and SDKs
* [View](https://developer.intuit.com/docs) our API documentation.
* [Test](https://developer.intuit.com/v2/apiexplorer?apiname=V3QBO) QuickbBooks API calls on the API Explorer.
* [Connect](https://developer.intuit.com/v2/help) with us and let us know if you have any questions, feedback or issues.
