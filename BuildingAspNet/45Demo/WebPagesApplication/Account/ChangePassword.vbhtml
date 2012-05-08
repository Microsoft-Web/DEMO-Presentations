﻿@Code
    WebSecurity.RequireAuthenticatedUser()

    Layout = "~/_SiteLayout.vbhtml"
    PageData("Title") = "Change Password"

    Dim isSuccess As Boolean = False
    Dim currentPassword As String = Request("currentPassword")
    Dim newPassword As String = Request("newPassword")
    Dim confirmPassword As String = Request("confirmPassword")

    ' Add Validation scripts
    Assets.AddScript("~/Scripts/jquery.validate.min.js")
    Assets.AddScript("~/Scripts/jquery.validate.unobtrusive.min.js")

    ' Setup validation
    Validation.RequireField("currentPassword", "The current password field is required.")
    Validation.RequireField("newPassword", "The new password field is required.")
    Validation.Add("confirmPassword",
        Validator.Required("The confirm new password field is required."),
        Validator.EqualsTo("newPassword", "The new password and confirmation password do not match."))

    If IsPost Then
        If Validation.IsValid() Then
            If WebSecurity.ChangePassword(WebSecurity.CurrentUserName, currentPassword, newPassword) Then
                isSuccess = True
            Else
                ModelState.AddFormError("An error occurred when attempting to change the password. Please contact the site owner.")
            End If
        Else
            ModelState.AddFormError("Password change was unsuccessful. Please correct the errors and try again.")
        End If
    End If
End Code

@If Not OAuthWebSecurity.IsAuthenticatedViaOAuth Then
    @<hgroup class="title">
        <h1>@PageData("Title").</h1>
        <h2>Use the form below to change your password.</h2>
    </hgroup>

    If isSuccess Then
        @<p class="message-success">
            Your password has been updated!
        </p>
    end if

    @<form method="post">
        @Html.ValidationSummary(excludeFieldErrors:=True)
        
        <fieldset>
            <legend>Change Password Form</legend>
            <ol>
                <li class="current-password">
                    <label for="currentPassword" @If Not ModelState.IsValidField("currentPassword") Then@<text>class="error-label"</text> End If>Current password</label>
                    <input type="password" id="currentPassword" name="currentPassword" @Validation.For("currentPassword")/>
                    @Html.ValidationMessage("currentPassword")
                </li>
                <li class="new-password">
                    <label for="newPassword" @If Not ModelState.IsValidField("newPassword") Then@<text>class="error-label"</text> End If>New password</label>
                    <input type="password" id="newPassword" name="newPassword" @Validation.For("newPassword")/>
                    @Html.ValidationMessage("newPassword")
                </li>
                <li class="confirm-password">
                    <label for="confirmPassword" @If Not ModelState.IsValidField("confirmPassword") Then@<text>class="error-label"</text> End If>Confirm password</label>
                    <input type="password" id="confirmPassword" name="confirmPassword" @Validation.For("confirmPassword")/>
                    @Html.ValidationMessage("confirmPassword")
                </li>
            </ol>
            <input type="submit" value="Change password" />
            <p>
                Click <a href="~/Account/ForgotPassword" title="Forgot password page">here</a> if you've forgotten your password.
            </p>
        </fieldset>
    </form>
End If

<div class="message-info">
    <p>
        To let users of this site log in using their accounts from other sites such as Facebook, Twitter, 
        and Windows Live, you must update this site. For more information <a href="http://go.microsoft.com/fwlink/?LinkID=226949">click here</a>.
    </p>
</div>
@*<p>
    Click <a href="~/Account/AssociateServiceAccount" title="Associate OAuth Account">here</a> to associate this account with an third party service log in.
</p>
<p>
    Click <a href="~/Account/DisassociateServiceAccount" title="Disassociate OAuth Account">here</a> to disassociate this account from an third party service log in.
</p>*@
