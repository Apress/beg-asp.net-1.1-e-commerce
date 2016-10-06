Public Class _default
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents pageContentsCell As System.Web.UI.HtmlControls.HtmlTableCell

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Save DepartmentID from the query string to a variable
        Dim departmentId As String = Request.QueryString("departmentID")
        ' Are we on the main web page or browsing the catalog?
        If Not departmentId Is Nothing Then
            Dim control As Control
            control = Page.LoadControl("UserControls/Catalog.ascx")
            pageContentsCell.Controls.Add(control)
        Else
            Dim control As Control
            control = Page.LoadControl("UserControls/FirstPage.ascx")
            pageContentsCell.Controls.Add(control)
        End If
    End Sub

End Class
