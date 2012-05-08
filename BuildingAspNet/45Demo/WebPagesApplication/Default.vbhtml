﻿@Code
    Layout = "~/_SiteLayout.vbhtml"
    PageData("Title") = "Home Page"
End Code

@Section featured
<section class="featured">
    <div class="content-wrapper">
        <hgroup class="title">
            <h1>@PageData("Title").</h1>
            <h2>Modify this template to jump-start your ASP.NET Web Pages application.</h2>
        </hgroup>
        <p>
            To learn more about ASP.NET Web Pages, visit <a href="http://asp.net/webpages" title="ASP.NET Web Pages Website">http://asp.net/webpages</a>. 
            The page features <span class="highlight">videos, tutorials, and samples</span> to help you get the most from 
            ASP.NET Web Pages. If you have any questions about ASP.NET Web Pages, visit 
            <a href="http://forums.iis.net/1166.aspx" title="ASP.NET Web Pages Forum">our forums</a>.
        </p>
    </div>
</section>
End Section

<h3>We suggest the following:</h3>

<ol class="round">
    <li class="one">
        <h5>Configure ASP.NET Membership</h5>
        ASP.NET membership gives you a built-in way to create, store, and 
        validate user credentials (authentication). 
        It also lets users log in using their Facebook or Twitter accounts.
    </li>
    <li class="two">
        <h5>Add NuGet packages and jump start your coding</h5>
        NuGet makes it easy to install and update free libraries in WebMatrix. 
        To install a package, go to the Files workspace and click the NuGet button in the ribbon.
    </li>
    <li class="three">
        <h5>Setup deployment to your web server</h5>
        Use FTP or Microsoft Web Deploy to quickly and easily publish your application to a web server. 
        Just click the Publish button in the ribbon and enter your credentials. For even easier deployment, 
        you can import publish settings that you get from your hosting provider.
    </li>
</ol>

<section class="features">
    <section class="feature">
        <img src="~/Images/aspNetHome.png" alt="" />
        <h3>Home of ASP.NET</h3>
        <p>
            ASP.NET is a free, fully supported Web application framework that helps you easily create great websites. 
            The <a href="http://asp.net">ASP.NET website</a> is your source for news, training, downloads, and support.
        </p>
    </section>
    <section class="feature">
        <img src="~/Images/NuGetGallery.png" alt="" />
        <h3>NuGet Gallery</h3>
        <p>
            NuGet is a WebMatrix extension that makes it easy to install and update libraries. Visit the 
            <a href="http://nuget.org">NuGet.org</a> site for more information.
        </p>
    </section>
    <section class="feature">
        <img src="~/Images/findHosting.png" alt="" />
        <h3>Find Web Hosting</h3>
        <p>
            You can easily find a web hosting company that offers the right mix of features and price for your applications. 
            Visit <a href="http://microsoft.com/web/hosting" title="Microsoft/Web Website">Microsoft.com/web</a> to 
            explore offerings from many providers.
        </p>
    </section>
</section>