Public Class ProductsList
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents DataList1 As System.Web.UI.WebControls.DataList
    Protected WithEvents list As System.Web.UI.WebControls.DataList

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
        ' Retrieve DepartmentID from the query string
        Dim departmentId As String = Request.QueryString("DepartmentID")
        ' Retrieve CategoryID from the query string
        Dim categoryId As String = Request.QueryString("CategoryID")
        ' Retrieve the SearchString from the query string
        Dim searchString As String = Request.QueryString("Search")

        If Not searchString Is Nothing Then
            ' search results
            list.DataSource = Session("SearchTable")
            list.DataBind()
            Session.Remove("SearchTable")
        ElseIf Not categoryId Is Nothing Then
            ' category
            list.DataSource = Catalog.GetProductsInCategory(categoryId)
            list.DataBind()
        ElseIf Not departmentId Is Nothing Then
            ' department
            list.DataSource = Catalog.GetProductsOnDepartmentPromotion(departmentId)
            list.DataBind()
        Else
            ' main page
            list.DataSource = Catalog.GetProductsOnCatalogPromotion()
            list.DataBind()
        End If
    End Sub

    Private Sub list_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles list.ItemCommand
        ' The CommandArgument of the Button that was clicked
        ' in the DataList contains the ProductID 
        Dim productId As String = e.CommandArgument
        ' Add the product to the shopping cart
        ShoppingCart.AddProduct(productId)
    End Sub
End Class
