@ModelType Homework1.客戶資料
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>客戶資料</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.客戶名稱)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.客戶名稱)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.統一編號)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.統一編號)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.電話)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.電話)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.傳真)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.傳真)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.地址)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.地址)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Email)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Email)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.IsDelete)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IsDelete)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
