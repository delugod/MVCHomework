Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Homework1

Namespace Controllers
    Public Class CustomerContactController
        Inherits System.Web.Mvc.Controller

        Private db As New CustomerEntities

        ' GET: CustomerContact
        Function Index(search As String) As ActionResult
            Dim 客戶聯絡人 = db.客戶聯絡人.Where(Function(c) c.IsDelete = False).Include(Function(客) 客.客戶資料)
            客戶聯絡人 = 客戶聯絡人.Where(Function(e) e.客戶資料.IsDelete = False)
            If String.IsNullOrEmpty(search) = False Then
                客戶聯絡人 = (From ent In 客戶聯絡人
                                Where ent.姓名.Contains(search))
            End If
            Return View(客戶聯絡人.ToList())
        End Function

        ' GET: CustomerContact/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim 客戶聯絡人 As 客戶聯絡人 = db.客戶聯絡人.Find(id)
            If IsNothing(客戶聯絡人) Then
                Return HttpNotFound()
            End If
            Return View(客戶聯絡人)
        End Function

        ' GET: CustomerContact/Create
        Function Create() As ActionResult
            ViewBag.客戶Id = New SelectList(db.客戶資料, "Id", "客戶名稱")
            Return View()
        End Function

        ' POST: CustomerContact/Create
        '若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        '詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,客戶Id,職稱,姓名,Email,手機,電話")> ByVal 客戶聯絡人 As 客戶聯絡人) As ActionResult
            If ModelState.IsValid Then
                If CheckEMailExist(客戶聯絡人.Email) = False Then
                    db.客戶聯絡人.Add(客戶聯絡人)
                    db.SaveChanges()
                    Return RedirectToAction("Index")
                Else
                    'todo:顯示email重複的文字
                End If
            End If
            ViewBag.客戶Id = New SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id)
            Return View(客戶聯絡人)
        End Function

        ' GET: CustomerContact/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim 客戶聯絡人 As 客戶聯絡人 = db.客戶聯絡人.Find(id)
            If IsNothing(客戶聯絡人) Then
                Return HttpNotFound()
            End If
            ViewBag.客戶Id = New SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id)
            Return View(客戶聯絡人)
        End Function

        ' POST: CustomerContact/Edit/5
        '若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        '詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,客戶Id,職稱,姓名,Email,手機,電話")> ByVal 客戶聯絡人 As 客戶聯絡人) As ActionResult
            If ModelState.IsValid Then
                db.Entry(客戶聯絡人).State = EntityState.Modified
                If CheckEMailExist(客戶聯絡人.Email, 客戶聯絡人.Id) = False Then
                    db.SaveChanges()
                    Return RedirectToAction("Index")
                Else
                    'todo:顯示email重複的文字
                End If
            End If
            ViewBag.客戶Id = New SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id)
            Return View(客戶聯絡人)
        End Function

        ' GET: CustomerContact/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim 客戶聯絡人 As 客戶聯絡人 = db.客戶聯絡人.Find(id)
            If IsNothing(客戶聯絡人) Then
                Return HttpNotFound()
            End If
            Return View(客戶聯絡人)
        End Function

        ' POST: CustomerContact/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim 客戶聯絡人 As 客戶聯絡人 = db.客戶聯絡人.Find(id)
            'db.客戶聯絡人.Remove(客戶聯絡人)
            客戶聯絡人.IsDelete = True
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function
        Function CheckEMailExist(EMail As String) As Boolean
            If db.客戶聯絡人.Where(Function(e) e.Email.Contains(EMail)).Any() Then
                Return True
            End If
            Return False
        End Function
        Function CheckEMailExist(EMail As String, ID As Integer) As Boolean
            If db.客戶聯絡人.Where(Function(e) e.Email.Contains(EMail) AndAlso e.Id <> ID).Any() Then
                Return True
            End If
            Return False
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace