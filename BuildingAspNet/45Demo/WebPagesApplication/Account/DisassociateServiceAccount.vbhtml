@Code
    Layout = "~/_SiteLayout.vbhtml"
    PageData("Title") = "Disassociate OAuth accounts"

    WebSecurity.RequireAuthenticatedUser()
    Dim accounts As IList(Of OAuthAccountData)

    If IsPost Then
        Dim provider As String = Request.Form("provider")
        Dim providerUserId As String = Request.Form("providerUserId")
        OAuthWebSecurity.DeleteAccount(provider, providerUserId)
    End If

    Dim username As String = WebSecurity.CurrentUserName
    accounts = OAuthWebSecurity.GetAccountsForUser(username)
End Code

<hgroup class="title">
    <h1>@PageData("Title").</h1>
    <h2>Choose a service to disassociate with this account.</h2>
</hgroup>

@If accounts IsNot Nothing AndAlso accounts.Count > 0 Then
    @<fieldset>
        <legend>Choose a service to disassociate with this account</legend>
        @For Each service As OAuthAccountData In accounts
            @<form method="post">
                <input type="hidden" name="providerUserId" value="@service.ProviderUserId" />
                <input type="submit" name="provider" id="@service.Provider" value="@service.Provider" title="Disassociate @(service.Provider + " - " + service.ProviderUserId) from this account." />
            </form>
        Next service
    </fieldset>
Else
    @<div class="message-info">
        <p>This account is not associated with any additional services.</p>
    </div>
End If