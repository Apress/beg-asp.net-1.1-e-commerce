Public Class _default
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents pageContentsCell As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents viewCartButton As System.Web.UI.WebControls.Button

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
        ' Save the search string from the query string to a variable
        Dim searchString As String = Request.QueryString("Search")
        ' We need to find out if the ViewCart parameter has been supplied
        Dim viewCart As String = Request.QueryString("ViewCart")
        ' Load page contents
        If Not viewCart Is Nothing Then
            ' we display the shopping cart
            Dim control As Control
            control = Page.LoadControl("UserControls/ShoppingCart.ascx")
            pageContentsCell.Controls.Add(control)
        ElseIf Not searchString Is Nothing Then
            ' you're searching the catalog 
            Dim control As Control
            control = Page.LoadControl("UserControls/SearchResults.ascx")
            pageContentsCell.Controls.Add(control)
        ElseIf Not departmentId Is Nothing Then
            ' you're visiting a department or category
            Dim control As Control
            control = Page.LoadControl("UserControls/Catalog.ascx")
            pageContentsCell.Controls.Add(control)
        Else
            ' you're on the main page
            Dim control As Control
            control = Page.LoadControl("UserControls/FirstPage.ascx")
            pageContentsCell.Controls.Add(control)
        End If
    End Sub

    Private Sub viewCartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles viewCartButton.Click
        ' Get the query string as a NameValueCollection object
        If Request.QueryString("ViewCart") Is Nothing Then
            Response.Redirect("default.aspx?ViewCart=1&" & _
              Request.QueryString.ToString())
        End If
    End Sub
End Class
