@ModelType Homework1.客戶銀行資訊
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>客戶銀行資訊</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.銀行名稱)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.銀行名稱)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.銀行代碼)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.銀行代碼)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.分行代碼)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.分行代碼)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.帳戶名稱)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.帳戶名稱)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.帳戶號碼)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.帳戶號碼)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.客戶資料.客戶名稱)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.客戶資料.客戶名稱)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
