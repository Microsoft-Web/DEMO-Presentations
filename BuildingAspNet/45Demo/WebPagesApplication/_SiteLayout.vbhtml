﻿<!DOCTYPE html>
<html lang="en">
    <head>
        <meta charset="utf-8" />
        <title>@PageData("Title") - My ASP.NET Web Page</title>
        <link href="~/Content/themes/base/jquery.ui.all.css" rel="stylesheet" type="text/css" />
        <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
        <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
        <script src="~/Scripts/jquery-1.6.2.min.js"></script>
        <script src="~/Scripts/jquery-ui-1.8.11.js"></script>
        <script src="~/Scripts/modernizr-2.0.6-development-only.js"></script>
        <script src="~/Scripts/AjaxLogin.js"></script>
        @* To enable bundling and minification turn on default bundles in app_start and replace script and css references with the following: 
        <link href="@System.Web.Optimization.BundleTable.Bundles.ResolveBundleUrl("~/Content/css")" rel="stylesheet" type="text/css" />
        <link href="@System.Web.Optimization.BundleTable.Bundles.ResolveBundleUrl("~/Content/themes/base/css")" rel="stylesheet" type="text/css" />
        <script src="@System.Web.Optimization.BundleTable.Bundles.ResolveBundleUrl("~/Scripts/js")"></script>*@
        <meta name="viewport" content="width=device-width" />
    </head>
    <body>
        <header>
            <div class="content-wrapper">
                <div class="float-left">
                    <p class="site-title"><a href="~/">your logo here.</a></p>
                </div>
                <div class="float-right">
                    <section id="login">
                        @If WebSecurity.IsAuthenticated Then
                            @<p>
                                Hello, <a class="username" href="~/Account/ChangePassword" title="Change password">@WebSecurity.CurrentUserName</a>!
                                <a href="~/Account/Logout">Logout</a>
                            </p>
                        Else
                            @<ul>
                                <li><a href="~/Account/Register">Register</a></li>
                                <li><a href="~/Account/Login">Log in</a></li>
                            </ul>
                        End If
                    </section>
                    <nav>
                        <ul id="menu">
                            <li><a href="~/">Home</a></li>
                            <li><a href="~/About">About</a></li>
                            <li><a href="~/Contact">Contact</a></li>
                        </ul>
                    </nav>
                </div>
            </div>
        </header>
        <div id="body">
            @RenderSection("featured", required:=false)
            <section class="content-wrapper main-content clear-fix">
                @RenderBody()
            </section>
        </div>
        <footer>
            <div class="content-wrapper">
                <div class="float-left">
                    <p>&copy; @DateTime.Now.Year - My ASP.NET Web Page</p>
                </div>
                <div class="float-right">
                    <ul id="social">
                        <li><a href="http://facebook.com" class="facebook">Facebook</a></li>
                        <li><a href="http://twitter.com" class="twitter">Twitter</a></li>
                    </ul>
                </div>
            </div>
        </footer>
        @Assets.GetScripts()
    </body>
</html>