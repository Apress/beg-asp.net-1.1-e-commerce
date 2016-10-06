Public Class ProductDetailsAdmin
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents productImage As System.Web.UI.WebControls.Image
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents productNameLink As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents categoriesListLabel As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents categoriesList As System.Web.UI.WebControls.DropDownList
    Protected WithEvents assignButton As System.Web.UI.WebControls.Button
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents categoriesList2 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents moveButton As System.Web.UI.WebControls.Button
    Protected WithEvents removeButton As System.Web.UI.WebControls.Button
    Protected WithEvents uploadFile As System.Web.UI.WebControls.Button
    Protected WithEvents uploadMessageLabel As System.Web.UI.WebControls.Label
    Protected WithEvents fileName As System.Web.UI.HtmlControls.HtmlInputFile

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    ' Will store the number of categories associated with the selected product
    Private categoriesCount As Integer = 0

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Get the ProductID from the query string
        Dim productId As String = Request.QueryString("ProductID")
        ' The control gets displayed only when a product is selected
        If Not IsNumeric(productId) Then
            Me.Visible = False
            ' Only reload data when the page is loaded for the first time
        ElseIf Not IsPostBack Then
            FillControls()
        End If
    End Sub

    Private Sub FillControls()
        ' Set the product name
        productNameLink.Text = Request.QueryString("ProductName")
        ' Display the product's image.
        productImage.ImageUrl = "../ProductImages/" & Request.QueryString("ImagePath")
        ' Get the ProductID from the query string
        Dim productId As String = Request.QueryString("ProductID")
        ' Get the list of categories into a SqlDataReader object
        Dim reader As SqlClient.SqlDataReader
        reader = CatalogAdmin.GetCategoriesForProduct(productId)
        ' Temporary variables we'll use in this method
        Dim categoryName As String
        Dim categoryId As String
        ' Read each category and add its name to the label
        categoriesListLabel.Text = ""
        While (reader.Read)
            ' extract the category ID from the SqlDataReader
            categoryId = reader.GetValue(0).ToString()
            ' extract the category name from the SqlDataReader
            categoryName = reader.GetValue(1).ToString()
            ' append category links to the Label
            categoriesListLabel.Text += _
               "<a href=""" + Request.Url.AbsolutePath + _
               "?DepartmentID=" + Request.QueryString("DepartmentID") + _
               "&CategoryID=" + categoryId + """>" + _
               categoryName + "</a>" + "; "
            ' increase the number of categories the selected product belongs to
            categoriesCount = categoriesCount + 1
        End While
        ' Set the text of the Delete button depending on
        ' the number of categories
        If categoriesCount = 1 Then
            ' Set the text on the Remove button
            removeButton.Text = "Remove product from catalog"
        Else
            ' Obtain the Category ID from the query string
            categoryId = Request.QueryString("CategoryID")
            ' Get the name of the current category from the database
            categoryName = Catalog.GetCategoryDetails(categoryId).Name
            ' Set the text on the Remove button
            removeButton.Text = "Remove product from category: " + categoryName
        End If
        ' Close the SqlDataReader. This will also close the data connection
        reader.Close()
        ' Get all the categories, to populate the DropDownList with them
        reader = CatalogAdmin.GetCategoriesForNotProduct(productId)
        ' Add the list of categories to the DropDownList objects
        categoriesList.Items.Clear()
        categoriesList2.Items.Clear()
        While (reader.Read)
            ' extract the category ID from the SqlDataReader
            categoryId = reader.GetValue(0).ToString()
            ' extract the category name from the SqlDataReader
            categoryName = reader.GetValue(1).ToString()
            ' add the category to the CategoriesList dropdown
            categoriesList.Items.Add(New ListItem(categoryName, categoryId))
            ' add the category to the CategoriesList2 dropdown
            categoriesList2.Items.Add(New ListItem(categoryName, categoryId))
        End While
        ' Close the SqlDataReader. This will also close the data connection
        reader.Close()
    End Sub

    Private Sub productNameLink_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles productNameLink.Click
        BackToCategory()
    End Sub

    Private Sub BackToCategory()
        ' The category currently selected by the user
        Dim categoryId As String = Request.QueryString("CategoryID")
        ' The department currently selected by the user
        Dim departmentId As String = Request.QueryString("DepartmentID")
        ' Redirect to the category admin page
        Response.Redirect("admin.aspx?DepartmentID=" & _
                          departmentId & "&CategoryID=" & categoryId)
    End Sub

    Private Sub assignButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles assignButton.Click
        ' The product currently selected by the user
        Dim productId As String = Request.QueryString("ProductID")
        ' Extract ID of the category that was selected in the DropDownList
        Dim categoryId As String = categoriesList.SelectedItem.Value
        ' Associate the product with the category
        CatalogAdmin.AssignProductToCategory(productId, categoryId)
        ' Update the page with the new info
        FillControls()
    End Sub

    Private Sub moveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles moveButton.Click
        ' The product currently selected by the user
        Dim productId As String = Request.QueryString("ProductID")
        ' The category currently selected by the user
        Dim oldCategoryId As String = Request.QueryString("CategoryID")
        ' The ID of the category that was selected in the DropDownList
        Dim newCategoryId As String = categoriesList2.SelectedItem.Value
        ' Associate the product with the category
        CatalogAdmin.MoveProductToCategory(productId, oldCategoryId, newCategoryId)
        ' Update the page with the new info
        BackToCategory()
    End Sub

    Private Sub removeButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles removeButton.Click
        ' The product currently selected by the user
        Dim productId As String = Request.QueryString("ProductID")
        ' The category currently selected by the user
        Dim categoryId As String = Request.QueryString("CategoryID")
        ' The department currently selected by the user
        Dim departmentId As String = Request.QueryString("DepartmentID")
        ' Remove the product
        CatalogAdmin.RemoveFromCategoryOrDeleteProduct(productId, categoryId)
        ' Redirect to the category admin page
        Response.Redirect("admin.aspx?DepartmentID=" & departmentId & "&CategoryID=" & categoryId)
    End Sub

    Private Sub uploadFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uploadFile.Click
        ' Get the full path of the downloaded file
        Dim imageFilePath As String = fileName.PostedFile.FileName
        ' Extract the file name from the path
        ' (we're not interested in the original client-side path)
        Dim imageFileName = System.IO.Path.GetFileName(imageFilePath)
        Try
            ' Save the file
            fileName.PostedFile.SaveAs(Server.MapPath("./ProductImages/") + _
                                                                 imageFileName)
            ' Update the database to reflect the new image file
            Dim productId = Request.QueryString("ProductID")
            CatalogAdmin.UpdateProductPicture(productId, imageFileName)
            ' If the upload is successful, redirect to the category page
            BackToCategory()
        Catch
            ' Show update failure message
            uploadMessageLabel.Text = "<BR><font color=red>Upload failed!"
        End Try
    End Sub
End Class