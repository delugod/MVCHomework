@ModelType IEnumerable(Of Homework1.客戶聯絡人)
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
            @Html.DisplayNameFor(Function(model) model.職稱)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.姓名)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Email)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.手機)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.電話)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.客戶資料.客戶名稱)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.職稱)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.姓名)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Email)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.手機)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.電話)
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
