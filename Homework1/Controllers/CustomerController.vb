Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Homework1

Namespace Controllers
    Public Class CustomerController
        Inherits System.Web.Mvc.Controller

        Private db As New CustomerEntities

        ' GET: Customer
        Function Index(search As String) As ActionResult
            Dim result = (From ent In db.客戶資料
                         Where ent.IsDelete = False).ToList()

            If String.IsNullOrEmpty(search) = False Then
                result = (From ent In result
                        Where ent.客戶名稱.Contains(search)).ToList()
            End If
            Return View(result)
        End Function

        ' GET: Customer/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim 客戶資料 As 客戶資料 = db.客戶資料.Find(id)
            If IsNothing(客戶資料) Then
                Return HttpNotFound()
            End If
            Return View(客戶資料)
        End Function

        ' GET: Customer/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Customer/Create
        '若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        '詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,客戶名稱,統一編號,電話,傳真,地址,Email")> ByVal 客戶資料 As 客戶資料) As ActionResult
            If ModelState.IsValid Then
                db.客戶資料.Add(客戶資料)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(客戶資料)
        End Function

        ' GET: Customer/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim 客戶資料 As 客戶資料 = db.客戶資料.Find(id)
            If IsNothing(客戶資料) Then
                Return HttpNotFound()
            End If
            Return View(客戶資料)
        End Function

        ' POST: Customer/Edit/5
        '若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        '詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,客戶名稱,統一編號,電話,傳真,地址,Email")> ByVal 客戶資料 As 客戶資料) As ActionResult
            If ModelState.IsValid Then
                db.Entry(客戶資料).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(客戶資料)
        End Function

        ' GET: Customer/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim 客戶資料 As 客戶資料 = db.客戶資料.Find(id)
            If IsNothing(客戶資料) Then
                Return HttpNotFound()
            End If
            Return View(客戶資料)
        End Function

        ' POST: Customer/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim 客戶資料 As 客戶資料 = db.客戶資料.Find(id)
            'db.客戶資料.Remove(客戶資料)
            客戶資料.IsDelete = True
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace