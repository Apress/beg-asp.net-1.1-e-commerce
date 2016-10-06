Public Class CategoriesAdmin
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents departmentNameLink As System.Web.UI.WebControls.LinkButton
    Protected WithEvents categoriesGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents nameTextBox As System.Web.UI.WebControls.TextBox
    Protected WithEvents descriptionTextBox As System.Web.UI.WebControls.TextBox
    Protected WithEvents addCategoryButton As System.Web.UI.WebControls.Button

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
        Dim departmentId As String = Request.QueryString("DepartmentID")
        ' Save CategoryID from the query string to a variable
        Dim categoryId As String = Request.QueryString("CategoryID")
        ' If no department is selected, or if a category is selected
        ' this control should be invisible
        If Not IsNumeric(departmentId) Or IsNumeric(categoryId) Then
            Me.Visible = False
        ElseIf Not Page.IsPostBack Then
            ' Update the data grid
            BindCategories()
            ' Retrieve the name of the department
            Dim departmentDetails As DepartmentDetails
            departmentDetails = Catalog.GetDepartmentDetails(departmentId)
            ' Set the text of departmentNameLabel
            departmentNameLink.Text = departmentDetails.Name
        End If
    End Sub

    Private Sub BindCategories()
        ' Save DepartmentID from the query string to a variable
        Dim departmentId As String = Request.QueryString("DepartmentID")
        ' Supply the data grid with the list of categories
        categoriesGrid.DataSource = CatalogAdmin.GetCategoriesWithDescriptions(departmentId)
        ' The DataKey of each row is the category ID.
        categoriesGrid.DataKeyField = "CategoryID"
        ' Bind the data grid to the data source
        categoriesGrid.DataBind()
    End Sub

    Private Sub categoriesGrid_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles categoriesGrid.EditCommand
        ' Enter the category into edit mode
        categoriesGrid.EditItemIndex = e.Item.ItemIndex
        ' Update the data grid
        BindCategories()
    End Sub

    Private Sub categoriesGrid_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles categoriesGrid.UpdateCommand
        Dim categoryId As String
        Dim categoryName As String
        Dim categoryDescription As String
        ' CategoryID is the DataKey field (set in BindDepartments)
        categoryId = categoriesGrid.DataKeys(e.Item.ItemIndex)
        ' We get the category name from the data grid
        categoryName = CType(e.Item.Cells(0).Controls(0), TextBox).Text
        ' We get the category description from the data grid
        categoryDescription = CType(e.Item.FindControl("editDescriptionTextBox"), TextBox).Text
        ' Pass the values to the business tier to update department info
        CatalogAdmin.UpdateCategory(categoryId, categoryName, categoryDescription)
        ' Cancel edit mode
        categoriesGrid.EditItemIndex = -1
        ' Update the data grid
        BindCategories()
    End Sub

    Private Sub categoriesGrid_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles categoriesGrid.CancelCommand
        ' Cancel edit mode
        categoriesGrid.EditItemIndex = -1
        ' Update the data grid
        BindCategories()
    End Sub

    Private Sub categoriesGrid_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles categoriesGrid.SelectedIndexChanged
        ' Get the department ID from the query string
        Dim departmentId As String = Request.QueryString("DepartmentID")
        ' CategoryID is the DataKey field for categoriesGrid
        Dim categoryId As String
        categoryId = categoriesGrid.DataKeys(categoriesGrid.SelectedIndex)
        ' Reload admin.aspx by specifying a DepartmentID and CategoryID
        Response.Redirect("admin.aspx?DepartmentID=" & departmentId & "&CategoryID=" & categoryId)
    End Sub


    Private Sub categoriesGrid_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles categoriesGrid.DeleteCommand
        Dim categoryId As String
        ' CategoryID is the DataKey field for categoriesGrid
        categoryId = categoriesGrid.DataKeys(e.Item.ItemIndex)
        ' We try to delete the category, but this will generate an exception
        ' if the category has related products in the database
        Try
            CatalogAdmin.DeleteCategory(categoryId)
            BindCategories()
        Catch ex As Exception
            ' Here we can show an error message specifying that the category
            ' can't be deleted. At the moment we simply redisplay the grid
            ' Update the data grid
            BindCategories()
        End Try
    End Sub

    Private Sub addCategoryButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addCategoryButton.Click
        ' Get the department ID from the query string
        Dim departmentId As String = Request.QueryString("DepartmentID")
        ' Add the new category to the database. Apart from specifying its name
        ' and description, we also mention the department it belongs to
        CatalogAdmin.AddCategory(departmentId, nameTextBox.Text, descriptionTextBox.Text)
        ' Update the data grid
        BindCategories()
    End Sub

    Private Sub departmentNameLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles departmentNameLink.Click
        ' Reload admin.aspx 
        Response.Redirect("admin.aspx")
    End Sub
End Class
