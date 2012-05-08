@*@Imports System.Web.Optimization*@
@Code
    WebSecurity.InitializeDatabaseConnection("StarterSite", "UserProfile", "UserId", "Email", autoCreateTables:=true)

    ' To let users of this site log in using their accounts from other sites such as Facebook, Twitter, 
    ' and Windows Live, you must update this site. For more information visit 
    ' http://go.microsoft.com/fwlink/?LinkID=226949

    ' OAuthWebSecurity.RegisterOAuthClient(
    '     BuiltInOAuthClient.WindowsLive,
    '     consumerKey:="test",
    '     consumerSecret:="test")

    ' OAuthWebSecurity.RegisterOAuthClient(
    '     BuiltInOAuthClient.Twitter,
    '     consumerKey:="",
    '     consumerSecret:="")
     
    ' for FB, consumerKey is called AppID by FB SDK
    ' OAuthWebSecurity.RegisterOAuthClient(
    '     BuiltInOAuthClient.Facebook,
    '     consumerKey:="",
    '     consumerSecret:="")

    ' WebMail.SmtpServer = "mailserver.example.com"
    ' WebMail.EnableSsl = True
    ' WebMail.UserName = "username@example.com"
    ' WebMail.Password = "your-password"
    ' WebMail.From = "your-name-here@example.com"
    
    ' To enable bundling and minification uncomment the following code as well as the using at the top, and replace script and css references.
    'BundleTable.Bundles.RegisterTemplateBundles()
End Code