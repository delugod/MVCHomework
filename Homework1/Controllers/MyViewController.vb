Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Homework1

Namespace Controllers
    Public Class MyViewController
        Inherits System.Web.Mvc.Controller

        Private db As New CustomerEntities

        ' GET: MyView
        Function Index() As ActionResult
            Return View(db.MyView.ToList())
        End Function

        ' GET: MyView/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim myView As MyView = db.MyView.Find(id)
            If IsNothing(myView) Then
                Return HttpNotFound()
            End If
            Return View(myView)
        End Function

        ' GET: MyView/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: MyView/Create
        '若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        '詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="id,客戶名稱,聯絡人數量,銀行數量")> ByVal myView As MyView) As ActionResult
            If ModelState.IsValid Then
                db.MyView.Add(myView)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(myView)
        End Function

        ' GET: MyView/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim myView As MyView = db.MyView.Find(id)
            If IsNothing(myView) Then
                Return HttpNotFound()
            End If
            Return View(myView)
        End Function

        ' POST: MyView/Edit/5
        '若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        '詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="id,客戶名稱,聯絡人數量,銀行數量")> ByVal myView As MyView) As ActionResult
            If ModelState.IsValid Then
                db.Entry(myView).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(myView)
        End Function

        ' GET: MyView/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim myView As MyView = db.MyView.Find(id)
            If IsNothing(myView) Then
                Return HttpNotFound()
            End If
            Return View(myView)
        End Function

        ' POST: MyView/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim myView As MyView = db.MyView.Find(id)
            db.MyView.Remove(myView)
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
