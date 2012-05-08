@Code
    Layout = "~/_SiteLayout.vbhtml"
    PageData("Title") = "Associate your account with OAuth & OpenID providers"

    WebSecurity.RequireAuthenticatedUser()

    Dim isSuccessful As Boolean = False
    Dim provider As String = Nothing

    If IsPost Then
        provider = Request.Form("provider")
        If Not provider.IsEmpty() Then
            OAuthWebSecurity.RequestAuthentication(provider)
            Return
        End If
    Else
        Dim result As AuthenticationResult = OAuthWebSecurity.VerifyAuthentication()
        If result.IsSuccessful Then
            Dim username As String = WebSecurity.CurrentUserName
            OAuthWebSecurity.CreateOrUpdateAccount(result.Provider, result.ProviderUserId, username)
            isSuccessful = True
            provider = result.Provider
        End If
    End If
End Code

<hgroup class="title">
    <h1>@PageData("Title").</h1>
    <h2>Choose a service to use to log in.</h2>
</hgroup>

@If isSuccessful Then
    @<p class="message-success">You have successfully associated this account with @provider.</p>
Else
    @<section class="social">
        <form method="post">
            <h2>Use another service to log in.</h2>
            <fieldset>
                <legend>Log in using another service</legend>
                <input type="submit" name="provider" id="facebook" value="Facebook" title="Log in using your Facebook account." />
                <input type="submit" name="provider" id="twitter" value="Twitter" title="Log in using your Twitter account." />
                <input type="submit" name="provider" id="windowsLive" value="Windows Live" title="Log in using your Windows Live account." />
            </fieldset>
        </form>
    </section>
End If