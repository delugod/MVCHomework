@ModelType IEnumerable(Of Homework1.客戶銀行資訊)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>
@Using (Html.BeginForm())
    @<input type="search" name="search" value="" placeholder="請輸入關鍵字" />
    @<input type="submit" value="搜尋" />
End Using
<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.銀行名稱)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.銀行代碼)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.分行代碼)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.帳戶名稱)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.帳戶號碼)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.客戶資料.客戶名稱)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.銀行名稱)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.銀行代碼)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.分行代碼)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.帳戶名稱)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.帳戶號碼)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.客戶資料.客戶名稱)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Id }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.Id }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.Id })
        </td>
    </tr>
Next

</table>
