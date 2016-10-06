Public Class ProductsAdmin
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents firstLabel As System.Web.UI.WebControls.Label
    Protected WithEvents categoryNameLink As System.Web.UI.WebControls.LinkButton
    Protected WithEvents productsGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents newProductLabel As System.Web.UI.WebControls.Label
    Protected WithEvents nameTextBox As System.Web.UI.WebControls.TextBox
    Protected WithEvents descriptionTextBox As System.Web.UI.WebControls.TextBox
    Protected WithEvents priceTextBox As System.Web.UI.WebControls.TextBox
    Protected WithEvents departmentPromotionCheck As System.Web.UI.WebControls.CheckBox
    Protected WithEvents createProductButton As System.Web.UI.WebControls.Button
    Protected WithEvents catPromListCheck As System.Web.UI.WebControls.CheckBox
    Protected WithEvents catalogPromotionCheck As System.Web.UI.WebControls.CheckBox

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
        ' Obtain the Category ID from the query string
        Dim categoryId As String = Request.QueryString("CategoryID")
        ' Obtain the Product ID from the query string
        Dim productId As String = Request.QueryString("ProductID")
        ' Set the label to its initial text
        firstLabel.Text = "Editing products for category:"
        ' Hide the control if a category was not selected,
        ' or if a product was selected
        If Not IsNumeric(categoryId) Or IsNumeric(productId) Then
            Me.Visible = False
        ElseIf Not Page.IsPostBack Then
            ' Populate the data grid with products
            BindProducts()
            ' Set categoryNameLabel.Text to the name of the selected category
            categoryNameLink.Text = Catalog.GetCategoryDetails(categoryId).Name
        End If
    End Sub

    Private Sub BindProducts()
        ' Obtain the Category ID from the query string
        Dim categoryId As String = Request.QueryString("CategoryID")
        ' Populate the data grid with the list of products that belong to
        ' the selected category
        productsGrid.DataSource = Catalog.GetProductsInCategory(categoryId)
        ' Set the DataKey field
        productsGrid.DataKeyField = "ProductID"
        ' Bind the grid to the data source
        productsGrid.DataBind()
    End Sub

    Private Sub categoryNameLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles categoryNameLink.Click
        ' Get the department ID from the query string
        Dim departmentId As String = Request.QueryString("DepartmentID")
        ' Reload admin.aspx by specifying the DepartmentID
        Response.Redirect("admin.aspx?DepartmentID=" & departmentId)
    End Sub

    Private Sub createProductButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles createProductButton.Click
        Dim categoryId As String = Request.QueryString("CategoryID")
        Dim productName As String = nameTextBox.Text
        Dim productDescription As String = descriptionTextBox.Text
        Dim productPrice As String = priceTextBox.Text
        Dim productImage As String = "GenericProduct.png"
        Dim onDepartmentPromotion As String = departmentPromotionCheck.Checked.ToString
        Dim onCatalogPromotion As String = catalogPromotionCheck.Checked.ToString
        Try
            ' Attempt to create the product and assign it to the category.
            ' If the operation is successful, the error message is cleared.
            CatalogAdmin.CreateProductToCategory(categoryId, productName, productDescription, productPrice, productImage, onDepartmentPromotion, onCatalogPromotion)
        Catch
            ' Here you can inform the user about the error.
            firstLabel.Text = "<font color=red>Could not create the product." _
                            & "Please verify the input values." _
                            & "</font><br>Editing products for category:"
        Finally
            ' Finally, no matter if an error occured or not, we update
            ' the products grid by calling BindProducts
            BindProducts()
        End Try
    End Sub

    Private Sub productsGrid_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles productsGrid.CancelCommand
        ' Exit edit mode
        productsGrid.EditItemIndex = -1
        BindProducts()
    End Sub

    Private Sub productsGrid_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles productsGrid.UpdateCommand
        Dim id As String
        Dim name As String
        Dim description As String
        Dim price As String
        Dim image As String
        Dim onDepartmentPromotion As String
        Dim onCatalogPromotion As String
        ' Gather product information
        id = productsGrid.DataKeys(e.Item.ItemIndex)
        name = CType(e.Item.Cells(1).Controls(0), TextBox).Text
        description = CType(e.Item.FindControl("editDescriptionTextBox"), TextBox).Text()
        price = CType(e.Item.Cells(3).Controls(0), TextBox).Text
        image = CType(e.Item.Cells(4).Controls(0), TextBox).Text
        onDepartmentPromotion = CType(e.Item.FindControl("deptPromListCheck"), CheckBox).Checked
        onCatalogPromotion = CType(e.Item.FindControl("catPromListCheck"), CheckBox).Checked
        Try
            ' Try to update the product info. If everything is OK clear the
            ' error label.
            CatalogAdmin.UpdateProduct(id, name, description, price, image, _
              onDepartmentPromotion, onCatalogPromotion)
        Catch
            ' Tell the visitor about the error
            firstLabel.Text = "<font color=red>Could not update product info." _
                            & "Please verify the input values.</font><br>" _
                            & "Editing products for category:"
        Finally
            ' No matter if an error occurs or not we cancel edit mode and 
            ' update the product’s grid information
            productsGrid.EditItemIndex = -1
            BindProducts()
        End Try
    End Sub

    Private Sub productsGrid_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles productsGrid.EditCommand
        ' Enter the grid into edit mode and rebind the data grid
        productsGrid.EditItemIndex = e.Item.ItemIndex
        BindProducts()
    End Sub

    Private Sub productsGrid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles productsGrid.SelectedIndexChanged
        Dim departmentId As String = Request.QueryString("DepartmentID")
        Dim categoryId As String = Request.QueryString("CategoryID")
        Dim productName As String = productsGrid.Items(productsGrid.SelectedIndex).Cells(1).Text
        Dim productId As String = productsGrid.DataKeys(productsGrid.SelectedIndex)
        Dim imagePath As String = productsGrid.Items(productsGrid.SelectedIndex).Cells(4).Text
        ' Send product info in the query string
        ' This is used in the ProductDetailsAdmin user control
        Response.Redirect("admin.aspx?DepartmentID=" & departmentId & "&CategoryID=" & categoryId & "&ProductID=" & productId & "&ProductName=" & productName & "&ImagePath=" & imagePath)
    End Sub
End Class