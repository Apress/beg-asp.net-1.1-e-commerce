Public Class Catalog1
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "
    Protected WithEvents sectionTitleLabel As System.Web.UI.WebControls.Label
    Protected WithEvents descriptionLabel As System.Web.UI.WebControls.Label

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

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
        ' If the visitor is browsing a category ...
        If Not categoryId Is Nothing Then
            ' Obtain category data in a CategoryDetails object
            Dim categoryDetails As New CategoryDetails
            categoryDetails = Catalog.GetCategoryDetails(categoryId)
            ' Display category info in the label controls
            sectionTitleLabel.Text = categoryDetails.Name
            descriptionLabel.Text = categoryDetails.Description
            ' If the visitor is browsing a department ...
        ElseIf Not departmentId Is Nothing Then
            ' Obtain department data in a DepartmentDetails object
            Dim departmentDetails As New DepartmentDetails
            departmentDetails = Catalog.GetDepartmentDetails(departmentId)
            ' Display department info in the label controls
            sectionTitleLabel.Text = departmentDetails.Name
            descriptionLabel.Text = departmentDetails.Description
        End If
    End Sub

End Class
