@Code
    Layout = "~/_SiteLayout.vbhtml"
    PageData("Title") = "Register an account"

    Dim email As String = ""

    ' Add Validation scripts
    Assets.AddScript("~/Scripts/jquery.validate.min.js")
    Assets.AddScript("~/Scripts/jquery.validate.unobtrusive.min.js")

    ' Setup validation
    Validation.RequireField("email", "The user name field is required.")

    If IsPost Then
        Dim result as AuthenticationResult = Session("OAuthResult")
        If result Is Nothing Then
            Response.Redirect("~/")
        End If

        email = Request.Form("email")
        
        If Validation.IsValid() Then
            ' Insert a new user into the database
            Dim db As Database = Database.Open("StarterSite")

            ' Check if user already exists
            Dim user As Object = db.QuerySingle("SELECT Email FROM UserProfile WHERE LOWER(Email) = LOWER(@0)", email)
            If user Is Nothing Then
                ' Insert email into the profile table
                db.Execute("INSERT INTO UserProfile (Email) VALUES (@0)", email)
                OAuthWebSecurity.CreateOrUpdateAccount(result.Provider, result.ProviderUserId, email)

                OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, False)

                Session.Remove("OAuthResult")
                
                Response.Redirect("~/")
            Else
                ModelState.AddError("email", "User name already exists. Please enter a different user name.")
            End If
        End If
    Else
        Dim result As AuthenticationResult = OAuthWebSecurity.VerifyAuthentication()
        If result.IsSuccessful Then
            ' put the ExtraData into the App property bag
            If result.ExtraData IsNot Nothing AndAlso result.ExtraData.Count > 0 Then
                Session.Add("OAuthExtraData", result.ExtraData)
            End If

            Dim registered As Boolean = OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, False)
            If registered Then                
                Dim returnUrl As String = Request.QueryString("ReturnUrl")
                If returnUrl.IsEmpty() Then
                    Response.Redirect("~/")
                Else
                    Context.RedirectLocal(returnUrl)
                End If
            Else
                Session("OAuthResult") = result
            End If
            ' set default user name to the value obtained from OAuth
            email = result.UserName
        Else
            ModelState.AddFormError("Unsuccessful log in with service.")
        End If
    End If
End Code

<hgroup class="title">
    <h1>@PageData("Title").</h1>
    <h2>Create an account on this site to associate to this service.</h2>
</hgroup>

<form method="post">
    @* If at least one validation error exists, notify the user *@
    @Html.ValidationSummary(excludeFieldErrors:=True)

    <fieldset>
        <legend>Registration Form</legend>
        <ol>
            <li class="email">
                <label for="email" @If Not ModelState.IsValidField("email") Then@<text>class="error-label"</text>End If>Email address</label>
                <input type="text" id="email" name="email" value="@email" @Validation.For("email") />
                @* Write any email validation errors to the page *@
                @Html.ValidationMessage("email")
            </li>
        </ol>
        <input type="submit" value="Associate" />
    </fieldset>
</form>