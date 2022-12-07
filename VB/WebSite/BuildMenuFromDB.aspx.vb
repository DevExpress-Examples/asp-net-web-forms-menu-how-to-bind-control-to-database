Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Collections.Generic

Public Partial Class ASPxperience_Menu_BuildMenuFromDB_BuildMenuFromDB
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        BuildMenu(ASPxMenu1, AccessDataSource1)
    End Sub

    Protected Sub BuildMenu(ByVal menu As DevExpress.Web.ASPxMenu, ByVal dataSource As SqlDataSource)
        ' Get DataView
        Dim arg As DataSourceSelectArguments = New DataSourceSelectArguments()
        Dim dataView As DataView = TryCast(dataSource.Select(arg), DataView)
        dataView.Sort = "ParentID"

        ' Build Menu Items
        Dim menuItems As Dictionary(Of String, DevExpress.Web.MenuItem) = New Dictionary(Of String, DevExpress.Web.MenuItem)()

        Dim i As Integer = 0
        Do While i < dataView.Count
            Dim row As DataRow = dataView(i).Row
            Dim item As DevExpress.Web.MenuItem = CreateMenuItem(row)
            Dim itemID As String = row("ID").ToString()
            Dim parentID As String = row("ParentID").ToString()

            If menuItems.ContainsKey(parentID) Then
                menuItems(parentID).Items.Add(item)
            Else
                If parentID = "0" Then ' It's Root Item
                    menu.Items.Add(item)
                End If
            End If
            menuItems.Add(itemID, item)
            i += 1
        Loop
    End Sub

    Private Function CreateMenuItem(ByVal row As DataRow) As DevExpress.Web.MenuItem
        Dim ret As DevExpress.Web.MenuItem = New DevExpress.Web.MenuItem()
        ret.Text = row("Text").ToString()
        ret.NavigateUrl = row("NavigateUrl").ToString()
        Return ret
    End Function
End Class