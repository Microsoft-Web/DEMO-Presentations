@Code
    Layout = "~/_SiteLayout.vbhtml"
    PageData("Title") = "Log in"

    ' Initialize general page variables
    Dim username As String = ""
    Dim password As String = ""
    Dim rememberMe As Boolean = False

    ' Add Validation scripts
    Assets.AddScript("~/Scripts/jquery.validate.min.js")
    Assets.AddScript("~/Scripts/jquery.validate.unobtrusive.min.js")

    ' Setup validation
    Validation.RequireField("username", "The user name field is required.")
    Validation.RequireField("password", "The password field is required.")

    ' If this is a POST request, validate and process data
    If IsPost Then
        ' is this a OAuth sign in request?
        Dim provider As String = Request.Form("provider")
        If Not Provider.IsEmpty() Then
            OAuthWebSecurity.RequestAuthentication(Provider, "~/Account/RegisterService")
            Return
        ElseIf Validation.IsValid() Then
            username = Request.Form("username")
            password = Request.Form("password")
            rememberMe = Request.Form("rememberMe").AsBool()

            If WebSecurity.UserExists(username) AndAlso WebSecurity.GetPasswordFailuresSinceLastSuccess(username) > 4 AndAlso WebSecurity.GetLastPasswordFailureDate(username).AddSeconds(60) > DateTime.UtcNow Then
                Response.Redirect("~/Account/AccountLockedOut")
                Return
            End If

            ' Attempt to log in to the Security object using provided creds
            If WebSecurity.Login(username, password, rememberMe) Then
                Dim returnUrl As String = Request.QueryString("ReturnUrl")
                If returnUrl.IsEmpty() Then
                    Response.Redirect("~/")
                Else
                    Context.RedirectLocal(returnUrl)
                End If
            Else
                ModelState.AddFormError("The user name or password provided is incorrect.")
            End If
        End If
    End If
End Code

<hgroup class="title">
    <h1>@PageData("Title").</h1>
    <h2>Enter your user name and password below.</h2>
</hgroup>

<section id="loginForm">
    <form method="post">
        @* If one or more validation errors exist, show an error *@
        @Html.ValidationSummary("Log in was unsuccessful. Please correct the errors and try again.", excludeFieldErrors:=True, htmlAttributes:=Nothing)

        <fieldset>
            <legend>Log in to Your Account</legend>
            <ol>
                <li class="username">
                    <label for="username" @If Not ModelState.IsValidField("username") Then@<text>class="error-label"</text> End If>User name</label>
                    <input type="text" id="username" name="username" value="@username" @Validation.For("username")/>
                    @* Write any user name validation errors to the page *@
                    @Html.ValidationMessage("username")
                </li>
                <li class="password">
                    <label for="password" @If Not ModelState.IsValidField("password") Then@<text>class="error-label"</text> End If>Password</label>
                    <input type="password" id="password" name="password" @Validation.For("password")/>
                    @* Write any password validation errors to the page *@
                    @Html.ValidationMessage("password")
                </li>
                <li class="remember-me">
                    <input type="checkbox" id="rememberMe" name="rememberMe" value="true" @If rememberMe Then@<text>checked="checked"</text> End If />
                    <label class="checkbox" for="rememberMe">Remember me?</label>
                </li>
            </ol>
            <input type="submit" value="Log in" />
        </fieldset>
    </form>
    <p>
        <a href="~/Account/Register">Don't have a Account?</a>
        <a href="~/Account/ForgotPassword">Did you forget your password?</a>
    </p>
</section>

<section class="social" id="socialLoginForm">
    <form method="post">
        <h2>Use another service to log in.</h2>
        <div class="message-info">
            <p>
                To let users of this site log in using their accounts from other sites such as Facebook, Twitter, 
                and Windows Live, you must update this site. For more information <a href="http://go.microsoft.com/fwlink/?LinkID=226949">click here</a>.
            </p>
        </div>
        @*<fieldset>
            <legend>Log in using another service</legend>
            <input type="submit" name="provider" id="facebook" value="Facebook" title="Log in using your Facebook account." />
            <input type="submit" name="provider" id="twitter" value="Twitter" title="Log in using your Twitter account." />
            <input type="submit" name="provider" id="windowsLive" value="WindowsLive" title="Log in using your Windows Live account." />
        </fieldset>*@
    </form>
</section>
