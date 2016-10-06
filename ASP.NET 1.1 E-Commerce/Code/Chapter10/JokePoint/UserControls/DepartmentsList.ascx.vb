Public Class DepartmentsList
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
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
        If Not IsPostBack Then
            ' The departmentIndex parameter is added to the query string when
            ' a department link is clicked. We need this because when the
            ' page is reloaded the DataList forgets which link was clicked.
            Dim listIndex As String = Request.QueryString("DepartmentIndex")

            ' If listIndex has a value, this tells us that the visitor
            ' has clicked on a department, and we inform the DataList about that
            ' (so it can apply the correct template for the selected item)
            If Not listIndex Is Nothing Then
                list.SelectedIndex = CInt(listIndex)
            End If

            ' GetDepartments returns an SqlDataReader object that has
            ' two fields: DepartmentID and Name. These fields are read in
            ' the SelectedItemTemplate and ItemTemplate of the DataList
            list.DataSource = Catalog.GetDepartments()

            ' Needed to bind the child controls (the HyperLink controls)
            ' to the data source
            list.DataBind()
        End If
    End Sub


End Class
