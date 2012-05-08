@Code
    ' Log out of the current user context
    WebSecurity.Logout()

    Session.Remove("OAuthExtraData")

    ' Redirect back to the homepage or return URL
    Dim returnUrl As String = Request.QueryString("ReturnUrl")
    If returnUrl.IsEmpty() Then
        Response.Redirect("~/")
    Else
        Context.RedirectLocal(returnUrl)
    End If
End Code