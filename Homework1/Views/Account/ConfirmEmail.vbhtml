﻿@Code
    ViewBag.Title = "確認電子郵件"
End Code

<h2>@ViewBag.Title.</h2>
<div>
    <p>
        感謝您確認您的電子郵件。請 @Html.ActionLink("Click here to Log in", "Login", "Account", routeValues:=Nothing, htmlAttributes:=New With {Key .id = "loginLink"})
    </p>
</div>
