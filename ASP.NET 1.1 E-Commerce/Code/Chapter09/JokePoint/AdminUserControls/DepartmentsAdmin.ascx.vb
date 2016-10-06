Public Class DepartmentsAdmin
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents departmentsGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents nameTextBox As System.Web.UI.WebControls.TextBox
    Protected WithEvents descriptionTextBox As System.Web.UI.WebControls.TextBox
    Protected WithEvents addDepartmentButton As System.Web.UI.WebControls.Button

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
        ' If no department is selected, this control should be invisible
        If IsNumeric(departmentId) Then
            Me.Visible = False
        ElseIf Not Page.IsPostBack Then
            ' Update the data grid
            BindDepartments()
        End If
    End Sub

    Private Sub BindDepartments()
        ' Supply the data grid with the list of departments
        departmentsGrid.DataSource = CatalogAdmin.GetDepartmentsWithDescriptions
        ' The DataKey of each row is the department's ID. We will use this
        ' when we need to get the department ID of a selected data row
        departmentsGrid.DataKeyField = "DepartmentID"
        ' Bind the data grid to the data source
        departmentsGrid.DataBind()
    End Sub

    Private Sub departmentsGrid_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles departmentsGrid.EditCommand
        ' We enter edit mode
        departmentsGrid.EditItemIndex = e.Item.ItemIndex
        ' Update the data grid
        BindDepartments()
    End Sub

    Private Sub departmentsGrid_UpdateCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles departmentsGrid.UpdateCommand
        Dim departmentId As String
        Dim departmentName As String
        Dim departmentDescription As String
        ' DepartmentID is the DataKey field (set in BindDepartments)
        departmentId = departmentsGrid.DataKeys(e.Item.ItemIndex)
        ' We get the department name from the data grid
        departmentName = CType(e.Item.Cells(0).Controls(0), TextBox).Text
        ' We get the department description from the data grid
        departmentDescription = CType(e.Item.FindControl("editDescriptionTextBox"), TextBox).Text
        ' Pass the values to the business tier to update department info
        CatalogAdmin.UpdateDepartment(departmentId, departmentName, departmentDescription)
        ' Cancel edit mode
        departmentsGrid.EditItemIndex = -1
        ' Update the data grid
        BindDepartments()
    End Sub

    Private Sub departmentsGrid_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles departmentsGrid.CancelCommand
        ' Cancel edit mode
        departmentsGrid.EditItemIndex = -1
        ' Update the data grid
        BindDepartments()
    End Sub

    Private Sub departmentsGrid_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles departmentsGrid.SelectedIndexChanged
        Dim departmentId As String
        ' DepartmentID is the DataKey field (set in BindDepartments)
        departmentId = departmentsGrid.DataKeys(departmentsGrid.SelectedIndex)
        ' We reload the page with a DepartmentID parameter in the query string
        Response.Redirect("admin.aspx?DepartmentID=" & departmentId)
    End Sub

    Private Sub departmentsGrid_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles departmentsGrid.DeleteCommand
        Dim departmentId As String
        ' DepartmentId is the DataKey field (set in BindDepartments)
        departmentId = departmentsGrid.DataKeys(e.Item.ItemIndex)
        ' We try to delete the department, but if it has related categories the
        ' database will generate an exception because this would violate its
        ' integrity
        Try
            CatalogAdmin.DeleteDepartment(departmentId)
            ' Update the data grid
            BindDepartments()
        Catch ex As Exception
            ' Here you can show an error message specifying the department
            ' can't be deleted. At the moment we simply redisplay the grid
            ' Update the data grid
            BindDepartments()
        End Try
    End Sub

    Private Sub addDepartmentButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addDepartmentButton.Click
        ' Add the new department to the database
        CatalogAdmin.AddDepartment(nameTextBox.Text, descriptionTextBox.Text)
        ' Update the data grid
        BindDepartments()
    End Sub
End Class