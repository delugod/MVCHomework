@ModelType IEnumerable(Of Homework1.客戶資料)
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
            @Html.DisplayNameFor(Function(model) model.客戶名稱)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.統一編號)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.電話)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.傳真)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.地址)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Email)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.客戶名稱)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.統一編號)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.電話)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.傳真)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.地址)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Email)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Id }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.Id }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.Id })
        </td>
    </tr>
Next

</table>
