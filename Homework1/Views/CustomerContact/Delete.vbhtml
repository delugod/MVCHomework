﻿@ModelType Homework1.客戶聯絡人
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>客戶聯絡人</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.職稱)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.職稱)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.姓名)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.姓名)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Email)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Email)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.手機)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.手機)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.電話)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.電話)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.客戶資料.客戶名稱)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.客戶資料.客戶名稱)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
