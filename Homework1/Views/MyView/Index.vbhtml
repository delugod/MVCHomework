@ModelType IEnumerable(Of Homework1.MyView)
@Code
    ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>

</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.客戶名稱)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.聯絡人數量)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.銀行數量)
        </th>
    </tr>

    @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.客戶名稱)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.聯絡人數量)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.銀行數量)
            </td>
        </tr>
    Next

</table>