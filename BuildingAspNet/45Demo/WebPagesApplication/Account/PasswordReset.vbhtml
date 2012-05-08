@Code
    Layout = "~/_SiteLayout.vbhtml"
    PageData("Title") = "Password Reset"

    Dim passwordResetToken As String = Request.Form("resetToken")
    Dim disabledAttribute As String = ""

    If passwordResetToken Is Nothing Then
        passwordResetToken = Request.QueryString("resetToken")
    End If
    
    Dim tokenExpired As Boolean = False
    Dim isSuccess As Boolean = False

    ' Add Validation scripts
    Assets.AddScript("~/Scripts/jquery.validate.min.js")
    Assets.AddScript("~/Scripts/jquery.validate.unobtrusive.min.js")

    ' Setup validation
    Validation.RequireField("newPassword", "The new password field is required.")
    Validation.Add("confirmPassword",
        Validator.EqualsTo("newPassword", "The new password and confirmation password do not match."))
    Validation.RequireField("passwordResetToken", "The password reset token field is required.")

    If IsPost AndAlso Validation.IsValid() Then
        Dim newPassword As String = Request("newPassword")
        Dim confirmPassword As String = Request("confirmPassword")

        If WebSecurity.ResetPassword(passwordResetToken, newPassword) Then
            disabledAttribute = "disabled=""disabled"""
            isSuccess = True
        Else
            ModelState.AddError("passwordResetToken", "The password reset token is invalid.")
            tokenExpired = True
        End If
    End If
End Code

<hgroup class="title">
    <h1>@PageData("Title").</h1>
    <h2>Use the form below to reset your password.</h2>
</hgroup>

@If Not WebMail.SmtpServer.IsEmpty() Then
    If Not Validation.IsValid() Then
        @<p class="validation-summary-errors">
            @If tokenExpired Then
                @<text>The password reset token is incorrect or may be expired. Visit the <a href="~/Account/ForgotPassword">forgot password page</a> 
                to generate a new one.</text>
            Else
                @<text>Could not reset password. Please correct the errors and try again.</text>
            End If
        </p>
    End If

    If isSuccess Then
        @<p class="message-success">
            Password changed! Click <a href="~/Account/Login" title="Log in">here</a> to log in.
        </p>
    End If

    @<form method="post">
        <fieldset>
            <legend>Password Change Form</legend>
            <ol>
                <li class="new-password">
                    <label for="newPassword" @If Not ModelState.IsValidField("newPassword") Then@<text>class="error-label"</text> End If>New password</label> 
                    <input type="password" id="newPassword" name="newPassword" @disabledAttribute @Validation.For("newPassword") />
                    @Html.ValidationMessage("newPassword")
                </li>
                <li class="confirm-password">
                    <label for="confirmPassword" @If Not ModelState.IsValidField("confirmPassword") Then@<text>class="error-label"</text> End If>Confirm password</label> 
                    <input type="password" id="confirmPassword" name="confirmPassword" @disabledAttribute @Validation.For("confirmPassword") />
                    @Html.ValidationMessage("confirmPassword")
                </li>
                <li class="reset-token">
                    <label for="resetToken" @If Not ModelState.IsValidField("resetToken") Then@<text>class="error-label"</text> End If>Password reset token</label> 
                    <input type="text" id="resetToken" name="resetToken" value="@passwordResetToken" @disabledAttribute @Validation.For("resetToken") />
                    @Html.ValidationMessage("resetToken")
                </li>
            </ol>
            <input type="submit" value="Reset password" @disabledAttribute/>
        </fieldset>
    </form>
Else
    @<p class="message-info">
        Password recovery is disabled for this website because the SMTP server is 
        not configured correctly. Please contact the owner of this site to reset 
        your password.
    </p>
End If
