Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Homework1

Namespace Controllers
    Public Class CustomerBankController
        Inherits System.Web.Mvc.Controller

        Private db As New CustomerEntities

        ' GET: CustomerBank
        Function Index(search As String) As ActionResult
            Dim 客戶銀行資訊 = db.客戶銀行資訊.Where(Function(c) c.IsDelete = False).Include(Function(客) 客.客戶資料)
            客戶銀行資訊 = 客戶銀行資訊.Where(Function(e) e.客戶資料.IsDelete = False)
            If String.IsNullOrEmpty(search) = False Then
                客戶銀行資訊 = (From ent In 客戶銀行資訊
                                Where ent.銀行名稱.Contains(search))
            End If
            Return View(客戶銀行資訊.ToList())
        End Function

        ' GET: CustomerBank/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim 客戶銀行資訊 As 客戶銀行資訊 = db.客戶銀行資訊.Find(id)
            If IsNothing(客戶銀行資訊) Then
                Return HttpNotFound()
            End If
            Return View(客戶銀行資訊)
        End Function

        ' GET: CustomerBank/Create
        Function Create() As ActionResult
            ViewBag.客戶Id = New SelectList(db.客戶資料, "Id", "客戶名稱")
            Return View()
        End Function

        ' POST: CustomerBank/Create
        '若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        '詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,客戶Id,銀行名稱,銀行代碼,分行代碼,帳戶名稱,帳戶號碼")> ByVal 客戶銀行資訊 As 客戶銀行資訊) As ActionResult
            If ModelState.IsValid Then
                db.客戶銀行資訊.Add(客戶銀行資訊)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.客戶Id = New SelectList(db.客戶資料, "Id", "客戶名稱", 客戶銀行資訊.客戶Id)
            Return View(客戶銀行資訊)
        End Function

        ' GET: CustomerBank/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim 客戶銀行資訊 As 客戶銀行資訊 = db.客戶銀行資訊.Find(id)
            If IsNothing(客戶銀行資訊) Then
                Return HttpNotFound()
            End If
            ViewBag.客戶Id = New SelectList(db.客戶資料, "Id", "客戶名稱", 客戶銀行資訊.客戶Id)
            Return View(客戶銀行資訊)
        End Function

        ' POST: CustomerBank/Edit/5
        '若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        '詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,客戶Id,銀行名稱,銀行代碼,分行代碼,帳戶名稱,帳戶號碼")> ByVal 客戶銀行資訊 As 客戶銀行資訊) As ActionResult
            If ModelState.IsValid Then
                db.Entry(客戶銀行資訊).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            ViewBag.客戶Id = New SelectList(db.客戶資料, "Id", "客戶名稱", 客戶銀行資訊.客戶Id)
            Return View(客戶銀行資訊)
        End Function

        ' GET: CustomerBank/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim 客戶銀行資訊 As 客戶銀行資訊 = db.客戶銀行資訊.Find(id)
            If IsNothing(客戶銀行資訊) Then
                Return HttpNotFound()
            End If
            Return View(客戶銀行資訊)
        End Function

        ' POST: CustomerBank/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim 客戶銀行資訊 As 客戶銀行資訊 = db.客戶銀行資訊.Find(id)
            'db.客戶銀行資訊.Remove(客戶銀行資訊)
            客戶銀行資訊.IsDelete = True
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