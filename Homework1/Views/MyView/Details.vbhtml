@ModelType Homework1.MyView
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>MyView</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.聯絡人數量)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.聯絡人數量)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.銀行數量)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.銀行數量)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.客戶名稱 }) |
    @Html.ActionLink("Back to List", "Index")
</p>
